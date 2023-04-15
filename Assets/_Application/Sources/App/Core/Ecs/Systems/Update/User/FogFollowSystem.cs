using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
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