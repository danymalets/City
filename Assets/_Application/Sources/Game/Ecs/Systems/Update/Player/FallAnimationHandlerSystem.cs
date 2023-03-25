using Scellecs.Morpeh;
using Sources.Game.Components.Old.PlayerAnimators;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;

namespace Sources.Game.Ecs.Systems.Update.Player
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