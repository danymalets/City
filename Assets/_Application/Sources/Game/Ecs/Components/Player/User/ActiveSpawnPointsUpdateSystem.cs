using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Player.User
{
    public class ActiveSpawnPointsUpdateSystem : DUpdateSystem
    {
        private Filter _pathesFilter;
        private Filter _userFilter;
        private readonly SimulationBalance _simulationBalance;

        public ActiveSpawnPointsUpdateSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnInitFilters()
        {
            _pathesFilter = _world.Filter<PathesTag>();
            _userFilter = _world.Filter<UserTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity userEntity = _userFilter.GetSingleton();
            Vector3 userPosition = userEntity.Get<UserFollowTransform>().Position;

            foreach (Entity pathEntity in _pathesFilter)
            {
                float sqrMinRadius = DMath.Sqr(_simulationBalance.MinActiveRadius);
                float sqrMaxRadius = DMath.Sqr(_simulationBalance.MaxActiveRadius);

                if (pathEntity.Has<CarsPathesTag>())
                {
                    sqrMinRadius += _simulationBalance.CarActiveRadiusDelta;
                    sqrMaxRadius += _simulationBalance.CarActiveRadiusDelta;
                }
                
                List<Point> allSpawnPoints = pathEntity.GetList<AllSpawnPoints, Point>();
                List<Point> activePoints = pathEntity.GetList<ActiveSpawnPoints, Point>();
                List<Point> horizonPoints = pathEntity.GetList<HorizonSpawnPoints, Point>();
                
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