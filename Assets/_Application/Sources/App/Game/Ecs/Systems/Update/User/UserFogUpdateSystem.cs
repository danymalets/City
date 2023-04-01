using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Player.User;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Monos;
using Sources.Monos.Bootstrap;
using Sources.Services.Di;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;

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