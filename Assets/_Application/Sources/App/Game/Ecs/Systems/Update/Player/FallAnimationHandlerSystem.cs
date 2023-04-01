using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Components.Old.PlayerAnimators;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;

namespace Sources.App.Game.Ecs.Systems.Update.Player
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