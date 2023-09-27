using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Services.Simulation;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Init.Pathes
{
    public class PathesPointsFindSystem : DInitializer
    {
        private Filter _filter;
        private readonly ISimulationSettings _simulationSettings;

        public PathesPointsFindSystem()
        {
            _simulationSettings = DiContainer.Resolve<ISimulationSettings>();
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PathesTag>().Build();
        }

        protected override void OnInitialize()
        {
            foreach (Entity pathesEntity in _filter)
            {
                List<Point> allPoints = pathesEntity.Get<AllPoints>().List;
                Dictionary<(int x, int y), List<Point>> allPointsGrid = pathesEntity.Get<AllSpawnPointsGrid>().Grid;
                List<Point> spawnPoints = pathesEntity.Get<AllSpawnPoints>().List;
                List<PathLine> pathLines = pathesEntity.Get<AllPathLines>().List;

                HashSet<Point> pointsSet = new();

                foreach (PathLine pathLine in pathLines)
                {
                    pointsSet.Add(pathLine.Source);
                    pointsSet.Add(pathLine.Target);
                }

                foreach (Point point in pointsSet)
                {
                    allPoints.Add(point);

                    if (point.IsSpawnPoint)
                    {
                        spawnPoints.Add(point);

                        Vector2 position = point.Position.GetXZ();

                        int x = DMath.Div(position.x, _simulationSettings.SimulationQuadWidth);
                        int y = DMath.Div(position.y, _simulationSettings.SimulationQuadWidth);

                        if (allPointsGrid.TryGetValue((x, y), out List<Point> exPoints))
                        {
                            exPoints.Add(point);
                        }
                        else
                        {
                            allPointsGrid.Add((x, y), new List<Point> { point });
                        }
                    }
                }
            }
        }
    }
}