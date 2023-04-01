using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Monos.Components.Old.PlayerAnimators;
using Sources.Utils.DMorpeh.DefaultComponents.Views;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.Player
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