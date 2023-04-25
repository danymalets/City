using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.NpcPathes;
using Sources.App.Core.Ecs.Components.SimulationAreas;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Services;
using Sources.App.Data;
using Sources.App.Data.Constants;
using Sources.App.Data.Points;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.NpcPathes
{
    public class ActiveSpawnPointsUpdateSystem : DIntervalUpdateSystem
    {
        private Filter _pathesFilter;
        private readonly ISimulationSettings _simulationSettings;

        public ActiveSpawnPointsUpdateSystem()
        {
            _simulationSettings = DiContainer.Resolve<ISimulationSettings>();
        }

        protected override void OnInitFilters()
        {
            _pathesFilter = _world.Filter<PathesTag>();
        }

        protected override float ExecuteInterval => (1f / 30f) * 3;

        protected override void OnIntervalUpdate(float deltaTime)
        {
            foreach (Entity pathEntity in _pathesFilter)
            {
                Dictionary<(int x, int y), List<Point>> allSpawnPointsGrid = pathEntity.Get<AllSpawnPointsGrid>().Grid;
                List<Point> activePoints = pathEntity.Get<ActiveSpawnPoints>().List;
                List<Point> allSpawnPoints = pathEntity.Get<AllSpawnPoints>().List;
                List<Point> horizonPoints = pathEntity.Get<HorizonSpawnPoints>().List;
                SimulationAreaData simulationAreaData = pathEntity.Get<RelatedSimulationArea>()
                    .SimulationAreaEntity.Get<SimulationArea>().AreaData;
                
                activePoints.Clear();
                horizonPoints.Clear();

                Vector2 position = simulationAreaData.Center;

                int centerX = DMath.Div(position.x, _simulationSettings.SimulationQuadWidth);
                int centerY = DMath.Div(position.y, _simulationSettings.SimulationQuadWidth);

                int debug = 0;

                for (int x = centerX - Consts.SimulationOneSideQuadCount;
                     x <= centerX + Consts.SimulationOneSideQuadCount; x++)
                {
                    for (int y = centerY - Consts.SimulationOneSideQuadCount;
                         y <= centerY + Consts.SimulationOneSideQuadCount; y++)
                    {
                        if (allSpawnPointsGrid.TryGetValue((x, y), out List<Point> points))
                        {
                            foreach (Point point in points)
                            {
                                debug++;
                                if (simulationAreaData.IsInsideBig(point.Position))
                                {
                                    if (simulationAreaData.IsInsideSmall(point.Position))
                                    {
                                        activePoints.Add(point);
                                    }
                                    else
                                    {
                                        horizonPoints.Add(point);
                                    }
                                }
                            }
                        }
                    }
                }
                
                // Debug.Log($"all spawn {allSpawnPoints.Count} need {activePoints.Count + horizonPoints.Count} solve {debug}");
            }
        }
    }
}