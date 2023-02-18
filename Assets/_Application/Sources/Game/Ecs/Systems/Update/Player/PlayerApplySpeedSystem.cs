using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.Physic;
using Sources.Game.Ecs.Components.Views.PlayerAnimators;
using Sources.Game.Ecs.Components.Views.PlayerDatas;
using Sources.Game.Ecs.Systems.Init;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class PlayerApplySpeedSystem : DUpdateSystem
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
                float targetSpeed = npcEntity.Get<PlayerTargetSpeed>().Value;
                float angle = npcEntity.Get<PlayerSmoothAngle>().Value;
                IPlayerAnimator playerAnimator = npcEntity.GetMono<IPlayerAnimator>();

                IPhysicBody physicBody = npcEntity.GetMono<IPhysicBody>();

                float ySpeed = physicBody.Velocity.y;
                
                physicBody.Velocity = (Quaternion.Euler(0,angle,0) * Vector3.forward * targetSpeed)
                    .WithY(ySpeed);
          
                playerAnimator.SetMoveSpeed(speed);
            }
        }
    }
}