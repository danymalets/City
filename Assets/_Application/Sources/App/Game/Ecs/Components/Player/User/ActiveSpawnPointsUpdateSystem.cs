using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Collections;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Data.RoadSystem.Pathes.Points;
using Sources.Di;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Extensions;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.App.Game.Ecs.Components.Player.User
{
    public class ActiveSpawnPointsUpdateSystem : DUpdateSystem
    {
        private Filter _pathesFilter;
        private Filter _userFilter;
        private readonly SimulationSettings _simulationSettings;

        public ActiveSpawnPointsUpdateSystem()
        {
            _simulationSettings = DiContainer.Resolve<SimulationSettings>();
        }

        protected override void OnConstruct()
        {
            _pathesFilter = _world.Filter<PathesTag>();
            _userFilter = _world.Filter<UserTag>();
        }

        protected override void OnUpdate(float deltaTime)
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