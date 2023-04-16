using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.NpcPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.ProjectServices.BalanceServices;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Init
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
                
                List<IRoad> roads = pathesEntity.Get<AllRoads>().List;
                List<PathLine> pathLines = pathesEntity.Get<AllPathLines>().List;
                List<ICrossroads> crossroads = pathesEntity.Get<AllCrossroads>().List;

                foreach (IRoad road in roads)
                {
                    foreach (IRoadLane roadLane in road.RoadLanes)
                    {
                        GeneratePathLines(pathLines, road, roadLane, isCar);
                    }
                }
            }
        }

        private void GeneratePathLines(List<PathLine> pathLines, IRoad road, IRoadLane roadLane, bool isCar)
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