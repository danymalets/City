using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Init
{
    public class RoadPathesGenerationSystem : DInitializer
    {
        private Filter _filter;
        private SimulationBalance _simulationBalance;

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

                foreach (Road road in roads)
                {
                    foreach (RoadLane roadLane in road.RoadLanes)
                    {
                        GeneratePathLines(ref pathLines, road, roadLane, isCar);
                    }
                }
            }
        }

        private void GeneratePathLines(ref ListOf<PathLine> pathLines, Road road, RoadLane roadLane, bool isCar)
        {
            List<Point> points = new();

            Vector3 source = roadLane.Source.Position;
            Vector3 target = roadLane.Target.Position;

            Vector3 direction = target - source;

            float lastDistance = isCar
                ? _simulationBalance.MaxBreakingDistance + 
                  _simulationBalance.CarRootToForwardPoint + 
                  _simulationBalance.CarDistanceAfterBreak + _simulationBalance.CrosswalkWidth
                : _simulationBalance.MaxNpcRadius + _simulationBalance.NpcDistanceAfterBreak;
            
            Vector3 preBreakPosition = Vector3.MoveTowards(target, source, lastDistance);

            float distance = Vector3.Distance(source, preBreakPosition);

            int pointsCount = Mathf.CeilToInt(distance / _simulationBalance.MinDistanceBetweenRoots) + 1;

            for (int i = 0; i <= pointsCount; i++)
            {
                float progress = (float)i / pointsCount;
                Vector3 position = Vector3.Lerp(source, preBreakPosition, progress);

                points.Add(new Point(position, direction, road.IsSpawnPoint));
            }
            
            points.Add(new Point(target, direction, false));

            for (int i = 0; i < points.Count - 1; i++)
            {
                pathLines.Add(new PathLine(points[i], points[i + 1]));
            }

            roadLane.Source.RelatedPoint = points[0];
            roadLane.Target.RelatedPoint = points[^1];
        }
    }
}