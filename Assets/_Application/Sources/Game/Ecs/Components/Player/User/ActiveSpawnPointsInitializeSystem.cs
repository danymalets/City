using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Player.User
{
    public class ActiveSpawnPointsInitializeSystem : DInitializer
    {
        private Filter _pathesFilter;
        private Filter _userFilter;
        private readonly ISpawnPoint _userSpawnPoint;
        private readonly SimulationBalance _simulationBalance;

        public ActiveSpawnPointsInitializeSystem()
        {
            _userSpawnPoint = DiContainer.Resolve<LevelContext>().UserSpawnPoint;

            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
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
                    _simulationBalance.CarMinActiveRadius :
                    _simulationBalance.NpcMinActiveRadius;

                float maxRadius = pathEntity.Has<CarsPathesTag>() ?
                    _simulationBalance.CarMaxActiveRadius :
                    _simulationBalance.NpcMaxActiveRadius;
                
                float backMinRadius = pathEntity.Has<CarsPathesTag>() ?
                    _simulationBalance.BackCarMinActiveRadius :
                    _simulationBalance.BackNpcMinActiveRadius;
                
                float backMaxRadius = pathEntity.Has<CarsPathesTag>() ?
                    _simulationBalance.BackCarMaxActiveRadius :
                    _simulationBalance.BackNpcMaxActiveRadius;
                
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