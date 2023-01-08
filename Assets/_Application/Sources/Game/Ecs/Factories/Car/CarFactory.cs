using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public class CarFactory : EcsFactory, ICarFactory
    {
        public CarFactory(World world) : base(world)
        {
        }

        public Entity CreateCar(CarMonoEntity carPrefab, Vector3 position, Quaternion rotation)
        {
            Entity car = _world.CreateFromMonoPrefab(carPrefab)
                .Add<CarTag>()
                .SetupMono<ITransform>(t => t.Position = position)
                .SetupMono<ITransform>(t => t.Rotation = rotation)
                .Add<CarMotorCoefficient>()
                .Add<CarBreak>()
                .Add<SteeringAngle>()
                .Add<SmoothSteeringAngle>()
                .Set(new MaxSpeed{Value = Mathf.Infinity})
                .Add<Physical>();
            
            return car;
        }
    }
}