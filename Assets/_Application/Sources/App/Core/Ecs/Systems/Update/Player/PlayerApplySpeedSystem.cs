using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Players;
using _Application.Sources.Utils.CommonUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Player
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