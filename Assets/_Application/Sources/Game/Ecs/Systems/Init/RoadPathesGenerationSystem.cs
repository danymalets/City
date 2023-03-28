using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
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

        protected override void OnConstruct()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
            _filter = _world.Filter<PathesTag>();
        }

        protected override void OnInitialize()
        {
            foreach (Entity pathesEntity in _filter)
            {
                bool isCar = pathesEntity.Has<CarsPathesTag>();
                
                List<Road> roads = pathesEntity.Get<AllRoads>().List;
                List<PathLine> pathLines = pathesEntity.Get<AllPathLines>().List;
                List<Crossroads> crossroads = pathesEntity.Get<AllCrossroads>().List;

                foreach (Road road in roads)
                {
                    foreach (RoadLane roadLane in road.RoadLanes)
                    {
                        GeneratePathLines(pathLines, road, roadLane, isCar);
                    }
                }
            }
        }

        private void GeneratePathLines(List<PathLine> pathLines, Road road, RoadLane roadLane, bool isCar)
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
            
            if (isCar)
            {
                Vector3 prePosition = Vector3.MoveTowards(target, source, _simulationBalance.CrosswalkWidth);
                points.Add(new Point(prePosition, direction, false));
            }
            
            points.Add(new Point(target, direction, false));

            
            for (int i = 0; i < points.Count - 1; i++)
            {
                pathLines.Add(new PathLine(points[i], points[i + 1], points[i + 1]));
            }

            roadLane.Source.RelatedPoint = points[0];
            roadLane.Target.RelatedPoint = points[^1];
        }
    }
}