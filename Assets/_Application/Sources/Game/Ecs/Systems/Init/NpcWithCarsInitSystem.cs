using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Init
{
    public class NpcWithCarsInitSystem : DInitializer
    {
        private IPathSystem _pathSystem;
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;
        private readonly LevelContext _levelContext;

        public NpcWithCarsInitSystem()
        {
            _assets = DiContainer.Resolve<Assets>();
            _levelContext = DiContainer.Resolve<LevelContext>();


            _physics = DiContainer.Resolve<IPhysicsService>();
        }

        protected override void OnInitFilters()
        {
        }

        protected override void OnInitialize()
        {
            _pathSystem = _world.GetMonoSingleton<IPathSystem>();

            List<IConnectingPoint> points = _pathSystem.RootPoints.ToList();
            points.RandomShuffle();
            
            foreach (IConnectingPoint point in points.Take(30))
            {
                CarMonoEntity carPrefab = _assets.CarsAssets.GetRandomCar();
                
                Collider[] colliders = _physics.OverlapBox(point.Position + point.Rotation *
                    carPrefab.CenterRelatedRootPoint, carPrefab.HalfExtents, point.Rotation, LayerMasks.Car);

                if (colliders.Length > 0)
                {
                    continue;
                }
                
                // GameObject deb = GameObject.CreatePrimitive(PrimitiveType.Cube);
                // GameObject.Destroy(deb.GetComponent<Collider>());
                // deb.transform.position = point.Position + point.Rotation * carPrefab.CenterRelatedRootPoint;
                // deb.transform.rotation = point.Rotation;
                // deb.transform.localScale = carPrefab.HalfExtents * 2;

                Entity car = _factory.CreateCar(carPrefab, point.Position - point.Rotation * carPrefab.RootOffset, point.Rotation);

                car.Set(new PlayerCarMaxSpeed { Value = 3f });
                
                _physics.SyncTransforms();
                
                _factory.CreateNpcInCar(car, point.GetRandomTargetPath());
            }
        }
    }
}