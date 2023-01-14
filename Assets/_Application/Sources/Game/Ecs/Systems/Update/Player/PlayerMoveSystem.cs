using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.PlayerAnimators;
using Sources.Game.Ecs.Components.Views.PlayerDatas;
using Sources.Game.Ecs.Systems.Init;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class PlayerMoveSystem : DFixedUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag>().Without<PlayerInCar>();
        }

        protected override void OnFixedUpdate(float fixedDeltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                float speed = npcEntity.Get<PlayerSpeed>().Value;
                float targetAngle = npcEntity.Get<SmoothAngle>().Value;
                IPlayerAnimator playerAnimator = npcEntity.GetMono<IPlayerAnimator>();
                
                npcEntity.GetMono<IPhysicBody>().Velocity = 
                    Quaternion.Euler(0,targetAngle,0) * Vector3.forward * speed;
          
                if (DMath.Greater(speed, 0))
                {
                    playerAnimator.SetMove();
                }
                else
                {
                    playerAnimator.SetIdle();
                }
            }
        }
    }
}