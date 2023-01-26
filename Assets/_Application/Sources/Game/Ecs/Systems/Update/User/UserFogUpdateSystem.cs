using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Systems.Update.User
{
    public class UserFogUpdateSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly Fog _fog;

        public UserFogUpdateSystem()
        {
            _fog = DiContainer.Resolve<LevelContext>().Fog;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<UserTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity userEntity = _filter.GetSingleton();

            UserFollowTransform userFollowTransform = userEntity.Get<UserFollowTransform>();

            _fog.Position = userFollowTransform.Position;
        }
    }
}