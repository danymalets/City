using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
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