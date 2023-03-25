using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.MorpehWrapper;

namespace Sources.Game.Ecs.Systems.Update.User
{
    public class PlayerFollowTransformUpdateSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PlayerTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ITransform transform = playerEntity.GetAccess<ITransform>();
                ref PlayerFollowTransform playerFollowTransform = ref playerEntity.Get<PlayerFollowTransform>();

                playerFollowTransform.Position = transform.Position;
                playerFollowTransform.Rotation = transform.Rotation;
            }
        }
    }
}