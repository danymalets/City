using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Components.Monos;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Player.User;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.DefaultComponents.Views;

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