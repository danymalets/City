using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.NpcPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.ProjectServices.BalanceServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Init
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
                List<PathLine> pathLines = pathesEntity.Get<AllPathLines>().List;
                List<ICrossroads> crossroads = pathesEntity.Get<AllCrossroads>().List;

                foreach (ICrossroads crossroad in crossroads)
                {
                    Generate(pathLines, crossroad, pathesEntity.Has<CarsPathesTag>());
                }
            }
        }

        private void Generate(List<PathLine> pathLines, ICrossroads crossroad, bool isCars)
        {
            IRoad[] crossroadRoads = crossroad.GetAllRoads();
            Vector3 crossroadPosition = crossroad.Position;

            for (int sourceIndex = 0; sourceIndex < crossroadRoads.Length; sourceIndex++)
            {
                IRoad sourceRoad = crossroadRoads[sourceIndex];

                foreach (int deltaIndex in s_deltaIndices)
                {
                    int targetIndex = DMath.Mod(sourceIndex + deltaIndex, crossroadRoads.Length);
                    IRoad targetRoad = crossroadRoads[targetIndex];

                    if (sourceRoad != null && targetRoad != null)
                    {
                        Point sourcePoint = sourceRoad.GetSideData(crossroadPosition).Targets.First();
                        Point targetPoint = targetRoad.GetSideData(crossroadPosition).Sources.First();
                        
                        Generate(pathLines, sourcePoint, targetPoint, deltaIndex);
                        
                        if (isCars)
                        {
                            sourcePoint.GetPreviousTurn().DependentPoint = sourcePoint;

                            sourcePoint.GetTurn(deltaIndex).DependentPoint = targetPoint;
                        }
                    }
                }
            }

            for (int sourceIndex = 0; sourceIndex < crossroadRoads.Length; sourceIndex++)
            {
                IRoad sourceRoad = crossroadRoads[sourceIndex];

                if (sourceRoad == null)
                    continue;

                List<TurnData> roadTurns = sourceRoad.GetSideData(crossroadPosition).Targets.First().Targets;

                foreach ((int delta, int banRoadDelta, int banTurnDelta) in s_banns)
                {
                    // Road targetRoad = crossroadRoads[DMath.Mod(sourceIndex + delta, crossroadRoads.Length)];
                    IRoad banRoad = crossroadRoads[DMath.Mod(sourceIndex + banRoadDelta, crossroadRoads.Length)];

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
        }

        private void Generate(List<PathLine> pathLines,
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

            pathLines.Add(new PathLine(points[0], points[1], points[^1], delta));

            for (int i = 1; i < points.Count - 1; i++)
            {
                pathLines.Add(new PathLine(points[i], points[i + 1], points[i + 1]));
            }
        }

        private Vector3 GetAnchorPoint(Point source, Point target) =>
            source.Position + source.Direction.normalized *
            DVector3.ManhattanDistance(source.Position, target.Position) / 2;
    }
}