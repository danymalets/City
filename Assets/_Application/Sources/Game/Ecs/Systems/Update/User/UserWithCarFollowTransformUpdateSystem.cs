using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views.CarEngine;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities.Extensions;

namespace Sources.Game.Ecs.Systems.Update.User
{
    public class UserWithCarFollowTransformUpdateSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<UserTag, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_filter.NoOne())
                return;
            
            Entity userEntity = _filter.GetSingleton();

            Entity carEntity = userEntity.Get<PlayerInCar>().Car;

            ICarWheels wheels = carEntity.GetMono<ICarWheels>();
            ITransform transform = carEntity.GetMono<ITransform>();
            ref UserFollowTransform userFollowTransform = ref userEntity.Get<UserFollowTransform>();

            userFollowTransform.Position = wheels.RootPosition;
            userFollowTransform.Rotation = transform.Rotation;
        }
    }
}