using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Player
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