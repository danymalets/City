using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class PlayerRotationSystem : DFixedUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, TargetAngle>().Without<PlayerInCar>();
        }

        protected override void OnFixedUpdate(float fixedDeltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ITransform transform = playerEntity.GetMono<ITransform>();
                float targetAngle = playerEntity.Get<TargetAngle>().Value;

                Vector3 eulerAngles = transform.Rotation.eulerAngles;

                float newAngle = Mathf.MoveTowardsAngle(eulerAngles.y, targetAngle,
                    180f * fixedDeltaTime);

                transform.Rotation = Quaternion.Euler(eulerAngles.WithY(newAngle));
            }
        }
    }
}