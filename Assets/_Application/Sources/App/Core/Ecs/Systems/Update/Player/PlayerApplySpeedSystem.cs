using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Players;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Player
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
                float targetSpeed = npcEntity.Get<PlayerTargetSpeed>().Value;
                float angle = npcEntity.Get<PlayerMoveAngle>().Value;

                IRigidbody physicBody = npcEntity.GetRef<IRigidbody>();
                
                float ySpeed = physicBody.Velocity.y;
                
                physicBody.Velocity = (Quaternion.Euler(0,angle,0) * Vector3.forward * targetSpeed)
                    .WithY(ySpeed);
            }
        }
    }
}