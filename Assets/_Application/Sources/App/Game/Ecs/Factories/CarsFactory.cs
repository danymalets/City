using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Aspects;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Data;
using Sources.Data.Cars;
using Sources.Data.Constants;
using Sources.Data.MonoEntities;
using Sources.Data.Points;
using Sources.Services.BalanceManager;
using Sources.Services.Di;
using Sources.Services.Physics;
using Sources.Utils.DMorpeh.DefaultComponents;
using Sources.Utils.DMorpeh.DefaultComponents.Views;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.App.Game.Ecs.Factories
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

        public bool TryCreateRandomCarOnPath(Point point, out Entity createdCar)
        {
            CarColorData carColorData = _carsBalance.GetRandomCar();
            ICarMonoEntity carPrefab = _assets.CarsAssets.GetCarPrefab(carColorData.CarType);

            bool has = _physics.CheckBox(point.Position + point.Rotation * carPrefab.CenterRelatedRootPoint,
                carPrefab.HalfExtents,  point.Rotation , LayerMasks.CarsAndPlayers);

            if (has)
            {
                createdCar = default;
                return false;
            }
            else
            {
                createdCar = CreateCar(carPrefab, carColorData.CarColor,
                    point.Position -  point.Rotation * carPrefab.RootOffset,  point.Rotation);
                return true;
            }
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