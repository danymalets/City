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

        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag>();
            _pathesFilter = _world.Filter<PathesTag>();
        }

        protected override void OnInitialize()
        {
            Vector3 userPosition = _userFilter.GetSingleton().Get<PlayerFollowTransform>().Position;

            foreach (Entity pathEntity in _pathesFilter)
            {
                float sqrMinRadius = DMath.Sqr(pathEntity.Has<CarsPathesTag>() ?
                    _simulationBalance.MinCarActiveRadius :
                    _simulationBalance.MinNpcActiveRadius);

                float sqrMaxRadius = DMath.Sqr(pathEntity.Has<CarsPathesTag>() ?
                    _simulationBalance.MaxCarActiveRadius :
                    _simulationBalance.MaxNpcActiveRadius);
                
                List<Point> allSpawnPoints = pathEntity.Get<AllSpawnPoints>().List;
                List<Point> activePoints = pathEntity.Get<ActiveSpawnPoints>().List;
                List<Point> horizonPoints = pathEntity.Get<HorizonSpawnPoints>().List;
                
                activePoints.Clear();
                horizonPoints.Clear();

                foreach (Point point in allSpawnPoints)
                {
                    float distance = DVector3.SqrDistance(userPosition, point.Position);
                    
                    if (distance < sqrMaxRadius)
                    {
                        if (distance < sqrMinRadius)
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