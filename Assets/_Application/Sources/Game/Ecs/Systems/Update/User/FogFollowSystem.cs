using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;

namespace Sources.Game.Ecs.Systems.Update.User
{
    public class FogFollowSystem : DUpdateSystem
    {
        private Filter _filter;

        public FogFollowSystem()
        {
            // _levelContext 
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<UserTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity userEntity = _filter.GetSingleton();
            
            PlayerFollowTransform playerFollowTransform = userEntity.Get<PlayerFollowTransform>();

            // playerFollowTransform.Position = wheels.RootPosition;
            // playerFollowTransform.Rotation = transform.Rotation;
        }
    }
}