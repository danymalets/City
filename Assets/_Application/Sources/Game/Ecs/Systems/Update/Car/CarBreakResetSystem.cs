using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class CarBreakResetSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<CarTag>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                IRigidbody physicBody = carEntity.GetAccess<IRigidbody>();
                ref CarBreak carBreak = ref carEntity.Get<CarBreak>();

                if (physicBody.Velocity == Vector3.zero)
                {
                    carBreak.BreakType = BreakType.None;
                }
            }
        }
    }
}