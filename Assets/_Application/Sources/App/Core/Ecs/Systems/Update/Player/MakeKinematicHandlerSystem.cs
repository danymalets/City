using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class MakeKinematicHandlerSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PlayerTag, MakeKinematicRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                IRigidbody physicBody = playerEntity.GetAccess<IRigidbody>();
                physicBody.MakeKinematic();
            }
        }
    }
}