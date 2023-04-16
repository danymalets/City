using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.GameObjects.Players.Ragdolls;
using Sources.App.Data.Cars;
using Sources.App.Data.Constants;
using Sources.App.Data.MonoEntities;
using Sources.App.Data.Points;
using Sources.CommonServices.PhysicsServices;
using Sources.ProjectServices.BalanceServices;
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

        public Entity CreateCar(CarColorData carColorData, Vector3 position, Quaternion rotation) =>
            CreateCar(_assets.CarsAssets.GetCarPrefab(carColorData.CarType), carColorData.CarColor,
                position, rotation);

        public Entity CreateRandomCar(Vector3 position, Quaternion rotation)
        {
            CarColorData carColorData = _balance.CarsBalance.GetRandomCar();
            return CreateCar(carColorData, position, rotation);
        }
        
        public bool TryCreateCar(ICarMonoEntity carPrefab, CarColorType? carColorType,
            Vector3 position, Quaternion rotation, out Entity createdCar)
        {
            if (CanCreateCar(carPrefab, position, rotation))
            {
                createdCar = CreateCar(carPrefab, carColorType,
                    position - rotation * carPrefab.RootOffset, rotation);
                return true;
            }
            else
            {
                createdCar = default;
                return false;
            }
        }

        public bool TryCreateCar(CarType carType, CarColorType? carColor, Vector3 position,
            Quaternion rotation, out Entity createdCar) =>
            TryCreateCar(_assets.CarsAssets.GetCarPrefab(carType), carColor, position,
                rotation, out createdCar);

        public bool CanCreateCar(ICarMonoEntity carPrefab, Vector3 position, Quaternion rotation)
        {
            return !_physics.CheckBox(position + rotation * carPrefab.CenterRelatedRootPoint,
                carPrefab.HalfExtents, rotation, LayerMasks.CarsAndPlayers);
        }

        public bool TryCreateRandomCarOnPath(Point point, out Entity createdCar)
        {
            CarColorData carColorData = _carsBalance.GetRandomCar();
            ICarMonoEntity carPrefab = _assets.CarsAssets.GetCarPrefab(carColorData.CarType);
            return TryCreateCar(carPrefab, carColorData.CarColor, point.Position, point.Rotation, out createdCar);
        }

        public Entity CreateCar(ICarMonoEntity carPrefab, CarColorType? colorType, Vector3 position, Quaternion rotation)
        {
            ICarMonoEntity carMonoEntity = _poolSpawner.Spawn(carPrefab, position, rotation);
            
            return _world.CreateFromMono(carMonoEntity)
                .Add<CarTag>()
                .SetAccess<IEnableableGameObject>(carMonoEntity.EnableableGameObject)
                .SetAccess<ITransform>(carMonoEntity.Transform)
                .SetAccess<IRigidbodySwitcher>(carMonoEntity.RigidbodySwitcher)
                .SetAccess<ICarEnterPoints>(carMonoEntity.EnterPoints)
                .SetAccess<ICarBorders>(carMonoEntity.BorderCollider)
                .SetAccess<IWheelsSystem>(carMonoEntity.WheelsSystem)
                .SetAccess<IMeshRenderer[]>(carMonoEntity.MeshRenderers.ToArray())
                .SetAccess<RigidbodySettings>(new RigidbodySettings(_carsBalance.Mass, RigidbodyConstraints.None,
                    carMonoEntity.BorderCollider.SafeBoxCollider.Center
                        .WithY(carMonoEntity.HalfExtents.y * 2) * (1f / 3f)))
                .SetupAspect<CarColorAspect>(cc =>
                {
                    if (colorType != null)
                        cc.SetupColor(colorType.Value);
                })
                .SetupAspect<SwitchableRigidbodyAspect>(pa => pa.EnablePhysicBody())
                .Add<CarMotorCoefficient>()
                .Add<CarBreak>()
                .Add<SteeringAngle>()
                .Add<ForwardTrigger>()
                .Add<SmoothSteeringAngle>()
                .Set(new CarPassengers(4))
                .Set(new CarMaxSpeed { Value = Mathf.Infinity });
        }
    }
}