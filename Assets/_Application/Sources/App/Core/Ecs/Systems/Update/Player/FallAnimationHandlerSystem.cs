using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Players;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Player
{
    public class FallAnimationHandlerSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PlayerTag, FallAnimationRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                IPlayerAnimator playerAnimator = playerEntity.GetAccess<IPlayerAnimator>();
                playerAnimator.SetDie();
            }
        }
    }
}