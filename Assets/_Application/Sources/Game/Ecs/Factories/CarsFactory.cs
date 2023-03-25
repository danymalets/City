using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Components.Old.CarEnterPointsData;
using Sources.Game.Components.Views;
using Sources.Game.Ecs.Aspects;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public class CarsFactory : Factory, ICarsFactory
    {
        private readonly CarsBalance _carsBalance;

        public CarsFactory(World world) : base(world)
        {
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
        }

        public Entity CreateCar(CarType carType, CarColorType carColor, Vector3 position, Quaternion rotation) =>
            CreateCar(_assets.CarsAssets.GetCarPrefab(carType), carColor, position, rotation);

        public Entity CreateRandomCar(Vector3 position, Quaternion rotation)
        {
            (CarType carType, CarColorType carColorType) = _balance.CarsBalance.GetRandomCar();
            return CreateCar(carType, carColorType, position, rotation);
        }

        public Entity CreateCar(CarMonoEntity carPrefab, CarColorType colorType, Vector3 position, Quaternion rotation)
        {
            CarMonoEntity carMonoEntity = _poolSpawner.Spawn(carPrefab, position, rotation);
            
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
                    if (colorType != CarColorType.None)
                        cc.SetupColor(colorType);
                })
                .SetupAspect<SwitchableRigidbodyAspect>(pa =>
                {
                    pa.EnablePhysicBody();
                })
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