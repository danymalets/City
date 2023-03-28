using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class DisableCollidersRequestHandlerSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PlayerTag, DisableCollidersRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                IRigidbody physicBody = playerEntity.GetAccess<IRigidbody>();
                physicBody.DetectCollisions = false;
            }
        }
    }
}