using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Car;
using Sources.App.Core.Ecs.Aspects.Common;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Data.Constants;
using Sources.App.Data.MonoEntities;
using Sources.App.Data.Points;
using Sources.App.Services.BalanceServices;
using Sources.Services.PhysicsServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;

namespace Sources.App.Core.Ecs.Factories
{
    public class CarsFactory : Factory, ICarsFactory
    {
        private readonly CarsBalance _carsBalance;
        private readonly IPhysicsService _physics;

        public CarsFactory()
        {
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
            _physics = DiContainer.Resolve<IPhysicsService>();
        }

        public bool TryCreateCar(CarType carType, CarColorType? carColor, Vector3 position,
            Quaternion rotation, bool isIdle, out Entity createdCar)
        {
            return TryCreateCar(_assets.CarsAssets.GetCarPrefab(carType), carColor, position,
                rotation, isIdle, out createdCar);
        }

        public bool TryCreateRandomCarOnPath(Point point, bool isIdle, out Entity createdCar)
        {
            CarColorData carColorData = _carsBalance.GetRandomCar();
            ICarMonoEntity carPrefab = _assets.CarsAssets.GetCarPrefab(carColorData.CarType);
            return TryCreateCar(carPrefab, carColorData.CarColor, point.Position, point.Rotation,
                isIdle, out createdCar);
        }

        private bool TryCreateCar(ICarMonoEntity carPrefab, CarColorType? carColorType,
            Vector3 position, Quaternion rotation, bool isIdle, out Entity createdCar)
        {
            if (CanCreateCar(carPrefab, position, rotation))
            {
                createdCar = CreateCar(carPrefab, carColorType,
                    position - rotation * carPrefab.WheelsSystem.RootOffset, rotation, isIdle);
                return true;
            }
            else
            {
                createdCar = default;
                return false;
            }
        }

        private bool CanCreateCar(ICarMonoEntity carPrefab, Vector3 position, Quaternion rotation)
        {
            return !_physics.CheckBox(position + rotation * (carPrefab.BorderCollider
                    .SafeBoxCollider.BoxColliderData.Center - carPrefab.WheelsSystem.RootOffset),
                carPrefab.BorderCollider.SafeBoxCollider.BoxColliderData.HalfExtents + 
                Vector3.one * 0.1f, rotation, LayerMasks.CarsAndPlayers);
        }

        private Entity CreateCar(ICarMonoEntity carPrefab, CarColorType? colorType,
            Vector3 position, Quaternion rotation, bool isIdle)
        {
            ICarMonoEntity carMonoEntity = _poolSpawner.Spawn(carPrefab, position, rotation);

            return _world.CreateFromMono(carMonoEntity)
                .Add<CarTag>()
                .SetRef<IEnableableGameObject>(carMonoEntity.EnableableGameObject)
                .SetRef<ITransform>(carMonoEntity.Transform)
                .SetRef<IRigidbodySwitcher>(carMonoEntity.RigidbodySwitcher)
                .SetRef<ICarBorders>(carMonoEntity.BorderCollider)
                .SetRef<IWheelsSystem>(carMonoEntity.WheelsSystem)
                .SetRef<IEnterPoint[]>(carMonoEntity.EnterPoints.EnterPoints.ToArray())
                .SetRef<IMeshRenderer[]>(carMonoEntity.MeshRenderers.ToArray())
                .SetRef<RigidbodySettings>(new RigidbodySettings(_carsBalance.Mass, RigidbodyConstraints.None,
                    carMonoEntity.BorderCollider.SafeBoxCollider.Center
                        .WithY(carMonoEntity.BorderCollider.SafeBoxCollider.BoxColliderData.HalfExtents.y * 2) * (1f / 3f)))
                .SetupAspectIf<CarColorAspect>(() => colorType != null,
                    cc => cc.SetupColor(colorType!.Value))
                .SetupAspectIf<SwitchableRigidbodyAspect>(() => !isIdle,
                    pa => pa.EnableRigidbody())
                .AddIf<Idle>(() => isIdle)
                .AddIf<AlwaysActive>(() => isIdle)
                .Add<CarMotorCoefficient>()
                .Add<CarBreak>()
                .Add<SteeringAngle>()
                .Add<SmoothSteeringAngle>()
                .Set(new CarPassengers { Passengers = Enumerable.Repeat<Entity>(null, 4).ToList() })
                .Set(new CarMaxSpeed { Value = Mathf.Infinity });
        }
    }
}