using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Tags;
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
            _pathesFilter = _world.Filter<PathesTag>();
        }

        protected override void OnInitialize()
        {
            Vector3 userPosition = _userSpawnPoint.Position;

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