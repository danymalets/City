using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils.MorpehWrapper;

namespace Sources.Game.Ecs.Systems.Update.User
{
    public class UserFollowTransformUpdateSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<UserTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity userEntity = _filter.GetSingleton();

            ITransform transform = userEntity.GetMono<ITransform>();
            ref UserFollowTransform userFollowTransform = ref userEntity.Get<UserFollowTransform>();

            userFollowTransform.Position = transform.Position;
            userFollowTransform.Rotation = transform.Rotation;
        }
    }
}