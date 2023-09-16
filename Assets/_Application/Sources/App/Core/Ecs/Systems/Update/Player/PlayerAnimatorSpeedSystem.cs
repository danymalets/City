using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Players;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerAnimatorSpeedSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                float speed = npcEntity.Get<PlayerSmoothSpeed>().Value;
                IPlayerAnimator playerAnimator = npcEntity.GetRef<IPlayerAnimator>();

                playerAnimator.SetMoveSpeed(speed);
            }
        }
    }
}