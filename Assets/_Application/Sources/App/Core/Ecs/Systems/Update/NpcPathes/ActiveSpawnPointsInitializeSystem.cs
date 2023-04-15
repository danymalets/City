using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.NpcPathes;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Services;
using Sources.App.Data.Common;
using Sources.App.Data.Points;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.NpcPathes
{
    public class ActiveSpawnPointsInitializeSystem : DInitializer
    {
        private Filter _pathesFilter;
        private Filter _userFilter;
        private readonly ISpawnPoint _userSpawnPoint;
        private readonly SimulationSettings _simulationSettings;

        public ActiveSpawnPointsInitializeSystem()
        {
            _userSpawnPoint = DiContainer.Resolve<ILevelContext>().UserSpawnPoint;

            _simulationSettings = DiContainer.Resolve<SimulationSettings>();
        }

        protected override void OnConstruct()
        {
            _userFilter = _world.Filter<UserTag>();
            _pathesFilter = _world.Filter<PathesTag>();
        }

        protected override void OnInitialize()
        {
            PlayerFollowTransform userTransform = _userFilter.GetSingleton().Get<PlayerFollowTransform>();

            foreach (Entity pathEntity in _pathesFilter)
            {
                float minRadius = pathEntity.Has<CarsPathesTag>() ?
                    _simulationSettings.CarMinActiveRadius :
                    _simulationSettings.NpcMinActiveRadius;

                float maxRadius = pathEntity.Has<CarsPathesTag>() ?
                    _simulationSettings.CarMaxActiveRadius :
                    _simulationSettings.NpcMaxActiveRadius;
                
                float backMinRadius = pathEntity.Has<CarsPathesTag>() ?
                    _simulationSettings.BackCarMinActiveRadius :
                    _simulationSettings.BackNpcMinActiveRadius;
                
                float backMaxRadius = pathEntity.Has<CarsPathesTag>() ?
                    _simulationSettings.BackCarMaxActiveRadius :
                    _simulationSettings.BackNpcMaxActiveRadius;
                
                List<Point> allSpawnPoints = pathEntity.Get<AllSpawnPoints>().List;
                List<Point> activePoints = pathEntity.Get<ActiveSpawnPoints>().List;
                List<Point> horizonPoints = pathEntity.Get<HorizonSpawnPoints>().List;
                
                activePoints.Clear();
                horizonPoints.Clear();

                foreach (Point point in allSpawnPoints)
                {
                    Vector2 directionToEntity = (Quaternion.Inverse(userTransform.Rotation) *
                                                 (point.Position - userTransform.Position)).GetXZ();

                    Vector2 minSize = new(minRadius, minRadius);
                    Vector2 maxSize = new(maxRadius, maxRadius);

                    if (directionToEntity.y < 0)
                    {
                        minSize.y = backMinRadius;
                        maxSize.y = backMaxRadius;
                    }
                    
                    if (DMath.InEllipse(directionToEntity, maxSize))
                    {
                        if (DMath.InEllipse(directionToEntity, minSize))
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