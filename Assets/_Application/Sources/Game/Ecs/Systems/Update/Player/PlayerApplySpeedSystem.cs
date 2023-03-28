using Scellecs.Morpeh;
using Sources.Game.Components.Old.PlayerAnimators;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class PlayerApplySpeedSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PlayerTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                float speed = npcEntity.Get<PlayerSmoothSpeed>().Value;
                float targetSpeed = npcEntity.Get<PlayerTargetSpeed>().Value;
                float angle = npcEntity.Get<PlayerSmoothAngle>().Value;
                IPlayerAnimator playerAnimator = npcEntity.GetAccess<IPlayerAnimator>();

                IRigidbody physicBody = npcEntity.GetAccess<IRigidbody>();
                
                float ySpeed = physicBody.Velocity.y;
                
                physicBody.Velocity = (Quaternion.Euler(0,angle,0) * Vector3.forward * targetSpeed)
                    .WithY(ySpeed);
          
                playerAnimator.SetMoveSpeed(speed);
            }
        }
    }
}