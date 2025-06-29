using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes;
using Sources.App.Core.Ecs.Components.SimulationAreas;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Data.Simulations;
using Sources.App.Core.Services.Simulation;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;
using Sources.App.Services.AssetsServices.Constants;
using Sources.Utils.CommonUtils.Utils;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.NpcPathes
{
    public class ActiveSpawnPointsUpdateSystem : CustomPeriodUpdateSystem
    {
        private Filter _pathesFilter;
        private readonly ISimulationSettings _simulationSettings;

        public ActiveSpawnPointsUpdateSystem()
        {
            _simulationSettings = DiContainer.Resolve<ISimulationSettings>();
        }

        protected override void OnInitFilters()
        {
            _pathesFilter = _world.Filter<PathesTag>().Build();
        }

        protected override int Period => 3;

        protected override void OnPeriodUpdate(float deltaTime)
        {
            foreach (Entity pathEntity in _pathesFilter)
            {
                Dictionary<(int x, int y), List<PathPoint>> allSpawnPointsGrid = pathEntity.Get<AllSpawnPointsGrid>().Grid;
                List<PathPoint> activePoints = pathEntity.Get<ActiveSpawnPoints>().List;
                List<PathPoint> horizonPoints = pathEntity.Get<HorizonSpawnPoints>().List;
                SimulationAreaData simulationAreaData = pathEntity.Get<RelatedSimulationArea>()
                    .SimulationAreaEntity.Get<SimulationArea>().AreaData;
                
                activePoints.Clear();
                horizonPoints.Clear();

                Vector2 position = simulationAreaData.Center;

                int centerX = MathUtils.Div(position.x, _simulationSettings.SimulationQuadWidth);
                int centerY = MathUtils.Div(position.y, _simulationSettings.SimulationQuadWidth);
                
                for (int x = centerX - Consts.SimulationOneSideQuadCount;
                     x <= centerX + Consts.SimulationOneSideQuadCount; x++)
                {
                    for (int y = centerY - Consts.SimulationOneSideQuadCount;
                         y <= centerY + Consts.SimulationOneSideQuadCount; y++)
                    {
                        if (allSpawnPointsGrid.TryGetValue((x, y), out List<PathPoint> points))
                        {
                            foreach (PathPoint point in points)
                            {
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
            }
        }
    }
}