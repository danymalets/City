using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public class CarFactory : EcsFactory, ICarFactory
    {
        public CarFactory(World world) : base(world)
        {
        }

        public Entity CreateCar(Vector3 position, Quaternion rotation)
        {
            return _world.CreateFromMonoPrefab(_assets.UserCarMonoEntity)
                .Add<CarTag>()
                .SetupMono<ITransform>(t => t.Position = position)
                .SetupMono<ITransform>(t => t.Rotation = rotation)
                .Add<Physical>();
        }
    }
}