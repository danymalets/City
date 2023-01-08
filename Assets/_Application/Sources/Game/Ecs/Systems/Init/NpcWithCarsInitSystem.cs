using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Scellecs.Morpeh;
using Sirenix.Utilities;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Factories.Npc;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Init
{
    public class NpcWithCarsInitSystem : DInitializer
    {
        private readonly ICarFactory _carFactory;
        private readonly INpcFactory _npcFactory;
        private IPathSystem _pathSystem;
        private readonly IPhysicsService _physics;
        private readonly IAssetsService _assets;
        private readonly ILevelContextService _levelContext;

        public NpcWithCarsInitSystem()
        {
            _carFactory = DiContainer.Resolve<ICarFactory>();
            _npcFactory = DiContainer.Resolve<INpcFactory>();
            _assets = DiContainer.Resolve<IAssetsService>();
            _levelContext = DiContainer.Resolve<ILevelContextService>();


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
                CarMonoEntity carPrefab = _assets.CarMonoEntity;
                
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

                Entity car = _carFactory.CreateCar(carPrefab, point.Position - point.Rotation * carPrefab.RootOffset, point.Rotation);

                car.Set(new MaxSpeed { Value = 3f });
                
                _physics.SyncTransforms();
                
                _npcFactory.Create(car, point.GetRandomTargetPath());
            }
        }
    }
}