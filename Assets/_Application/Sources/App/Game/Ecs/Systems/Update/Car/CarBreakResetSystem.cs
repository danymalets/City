using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.Car
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