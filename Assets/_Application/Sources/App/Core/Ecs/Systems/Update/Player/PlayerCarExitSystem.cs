using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Data.Constants;
using Sources.App.Data.Players;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerCarExitSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, PlayerInCar, PlayerExitCarEvent>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                IPlayerAnimator playerAnimator = playerEntity.GetRef<IPlayerAnimator>();
                
                playerEntity.Remove<PlayerFullyInCar>();
                playerEntity.AddWithFixedDelay<PlayerFullyExitCarEvent>(Consts.ExitCarAnimationDuration + 1f);
                playerAnimator.ExitCar();
                Debug.Log($"exit car anim");
            }
        }
    }
}