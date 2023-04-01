using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.DefaultComponents.Views;

namespace Sources.App.Game.Ecs.Systems.Update.Player
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