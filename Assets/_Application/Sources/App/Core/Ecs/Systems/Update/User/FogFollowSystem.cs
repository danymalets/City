using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.User
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