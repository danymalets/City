using _Application.Sources.MonoViews.MonoViews;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Player.User;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.DMorpeh.DefaultComponents.Views;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;

namespace Sources.App.Game.Ecs.Systems.Update.User
{
    public class PlayerWithCarFollowTransformUpdateSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PlayerTag, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                Entity carEntity = playerEntity.Get<PlayerInCar>().Car;
                
                IWheelsSystem wheels = carEntity.GetAccess<IWheelsSystem>();
                ITransform transform = carEntity.GetAccess<ITransform>();
                ref PlayerFollowTransform playerFollowTransform = ref playerEntity.Get<PlayerFollowTransform>();

                playerFollowTransform.Position = wheels.RootPosition;
                playerFollowTransform.Rotation = transform.Rotation;
            }
        }
    }
}