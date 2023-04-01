using _Application.Sources.Monos.Bootstrap;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Player.User;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Infrastructure.Bootstrap;
using Sources.Di;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;

namespace Sources.App.Game.Ecs.Systems.Update.User
{
    public class UserFogUpdateSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly Fog _fog;

        public UserFogUpdateSystem()
        {
            _fog = DiContainer.Resolve<LevelContext>().Fog;
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<UserTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity userEntity = _filter.GetSingleton();

            PlayerFollowTransform playerFollowTransform = userEntity.Get<PlayerFollowTransform>();

            _fog.Position = playerFollowTransform.Position;
        }
    }
}