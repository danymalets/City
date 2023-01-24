using System;
using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Init
{
    public class CrossroadsPathesGenerationSystem : DInitializer
    {
        private Filter _filter;
        private SimulationBalance _simulationBalance;

        private static readonly int[] s_deltaIndices = { -2, -1, +1 };

        private static readonly Dictionary<int, int> s_pointsCountByDelta = new() { [-2] = 1, [-1] = 9, [+1] = 3 };

        private static readonly (int Delta, int banRoadDelta, int banTurnDelta)[] s_banns =
        {
            (-2, -2, -1), (-2, -1, -2), (-2, -1, -1), (-2, +1, -2), (-2, +1, -1), (-2, +1, +1),
            (-1, -2, -2), (-1, -2, -1), (-1, -2, +1), (-1, -1, -2), (-1, -1, -1), (-1, +1, -2), (-1, +1, -1), (-1, +1, +1),
            (+1, -2, -1), (+1, -1, -1), (+1, -1, -2),
        };

        protected override void OnInitFilters()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
            _filter = _world.Filter<PathesTag>();
        }

        protected override void OnInitialize()
        {
            foreach (Entity pathesEntity in _filter)
            {
                bool isCar = pathesEntity.Has<CarsPathesTag>();

                ref ListOf<Road> roads = ref pathesEntity.Get<ListOf<Road>>();
                ref ListOf<Crossroads> crossroads = ref pathesEntity.Get<ListOf<Crossroads>>();
                ref ListOf<PathLine> pathLines = ref pathesEntity.Get<ListOf<PathLine>>();

                foreach (Crossroads crossroad in crossroads)
                {
                    Generate(ref pathLines, crossroad);
                }
            }
        }

        private void Generate(ref ListOf<PathLine> pathLines, Crossroads crossroad)
        {
            Road[] crossroadRoads = crossroad.GetAllRoads();
            Vector3 crossroadPosition = crossroad.transform.position;

            for (int sourceIndex = 0; sourceIndex < crossroadRoads.Length; sourceIndex++)
            {
                Road sourceRoad = crossroadRoads[sourceIndex];

                foreach (int deltaIndex in s_deltaIndices)
                {
                    int targetIndex = DMath.Mod(sourceIndex + deltaIndex, crossroadRoads.Length);
                    Road targetRoad = crossroadRoads[targetIndex];

                    if (sourceRoad != null && targetRoad != null)
                    {
                        Point sourcePoint = sourceRoad.GetSideData(crossroadPosition).Targets.First();
                        Point targetPoint = targetRoad.GetSideData(crossroadPosition).Sources.First();

                        Generate(ref pathLines, sourcePoint, targetPoint, deltaIndex);
                    }
                }
            }

            for (int sourceIndex = 0; sourceIndex < crossroadRoads.Length; sourceIndex++)
            {
                Road sourceRoad = crossroadRoads[sourceIndex];

                if (sourceRoad == null)
                    continue;

                List<TurnData> roadTurns = sourceRoad.GetSideData(crossroadPosition).Targets.First().Targets;

                foreach ((int delta, int banRoadDelta, int banTurnDelta) in s_banns)
                {
                    // Road targetRoad = crossroadRoads[DMath.Mod(sourceIndex + delta, crossroadRoads.Length)];
                    Road banRoad = crossroadRoads[DMath.Mod(sourceIndex + banRoadDelta, crossroadRoads.Length)];

                    if (banRoad == null)
                        continue;

                    List<TurnData> banTargets = banRoad.GetSideData(crossroadPosition).Targets.First().Targets;

                    if (roadTurns.NoOne(rt => rt.Delta == delta))
                        continue;

                    TurnData turnData = roadTurns.First(rt => rt.Delta == delta);

                    if (banTargets.NoOne(bt => bt.Delta == banTurnDelta))
                        continue;

                    TurnData banTurnData = banTargets.First(bt => bt.Delta == banTurnDelta);
                    
                    turnData.BlockableTurns.Add(banTurnData);
                }
            }

            GenerateCrosswalksBlocks(crossroad, crossroad.Forward, crossroad.ForwardRelated);
            GenerateCrosswalksBlocks(crossroad, crossroad.Left, crossroad.LeftRelated);
            GenerateCrosswalksBlocks(crossroad, crossroad.Back, crossroad.BackRelated);
            GenerateCrosswalksBlocks(crossroad, crossroad.Right, crossroad.RightRelated);
        }

        private void Generate(ref ListOf<PathLine> pathLines,
            Point source, Point target, int delta)
        {
            int pointsCount = s_pointsCountByDelta[delta];

            List<Point> points = new();

            Vector3 anchor = GetAnchorPoint(source, target);

            Vector3 sourcePosition = source.Position;
            Vector3 targetPosition = target.Position;

            points.Add(source);

            for (int i = 1; i <= pointsCount - 1; i++)
            {
                float progress = (float)i / pointsCount;
                Vector3 first = Vector3.Lerp(sourcePosition, anchor, progress);
                Vector3 second = Vector3.Lerp(anchor, targetPosition, progress);
                Vector3 result = Vector3.Lerp(first, second, progress);

                points.Add(new Point(result, second - first, false));
            }

            points.Add(target);

            pathLines.Add(new PathLine(points[0], points[1], delta, points[^1]));

            for (int i = 1; i < points.Count - 1; i++)
            {
                pathLines.Add(new PathLine(points[i], points[i + 1]));
            }
        }

        private void GenerateCrosswalksBlocks(Crossroads crossroads, Road road, Road crosswalk)
        {
            if (road == null || crosswalk == null)
                return;
            
            CrossroadsSideData roadSideData = road.GetSideData(crossroads.transform.position);
            RoadLane[] crosswalkLanes = crosswalk.GetLanesByDistanceTo(crossroads.transform.position);

            Point roadSource = roadSideData.Sources.First();
            Point roadTarget = roadSideData.Targets.First();
            
            RoadLane firstCrosswalkLane = crosswalkLanes[0];
            RoadLane secondCrosswalkLane = crosswalkLanes[1];

            Point firstCrosswalkLaneSource = firstCrosswalkLane.Source.RelatedPoint;
            Point firstCrosswalkLaneTarget = firstCrosswalkLane.Target.RelatedPoint;
            Point secondCrosswalkLaneSource = secondCrosswalkLane.Source.RelatedPoint;
            Point secondCrosswalkLaneTarget = secondCrosswalkLane.Target.RelatedPoint;

            firstCrosswalkLaneSource.Targets.First().TargetPoint = firstCrosswalkLaneTarget;
            firstCrosswalkLaneSource.Targets.First().BlockableTurns.Add(roadSource.GetSimpleTurn());
            firstCrosswalkLaneSource.Targets.First().BlockableTurns.Add(roadTarget.GetSimpleSourceTurn());  
            
            secondCrosswalkLaneSource.Targets.First().TargetPoint = secondCrosswalkLaneTarget;
            secondCrosswalkLaneSource.Targets.First().BlockableTurns.Add(roadSource.GetSimpleTurn());
            secondCrosswalkLaneSource.Targets.First().BlockableTurns.Add(roadTarget.GetSimpleSourceTurn());
        }

        private Vector3 GetAnchorPoint(Point source, Point target) =>
            source.Position + source.Direction.normalized *
            DVector3.ManhattanDistance(source.Position, target.Position) / 2;
    }
}