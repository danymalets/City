using System;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Car
{
    public class CarBreakApplySystem : DUpdateSystem
    {
        private const float BreakTorqueLite = 1.5f;
        private const float BreakTorqueMax = 1_000_000_000f;
        
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<CarTag>().Build();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                AxleInfo[] axleInfos = carEntity.GetRef<IWheelsSystem>().AxleInfo;
                BreakType breakType = carEntity.Get<CarBreak>().BreakType;

                for (int i = 0; i < axleInfos.Length; i++)
                {
                    AxleInfo axleInfo = axleInfos[i];
                    axleInfo.LeftWheelCollider.brakeTorque = GetBreak(breakType) * (i == 0 ? 70 : 30);
                    axleInfo.RightWheelCollider.brakeTorque = GetBreak(breakType)  * (i == 0 ? 70 : 30);
                }
            }
        }

        private float GetBreak(BreakType breakType)
        {
            return breakType switch
            {
                BreakType.None => 0,
                BreakType.Lite => BreakTorqueLite,
                BreakType.Max => BreakTorqueMax,
                _ => throw new ArgumentOutOfRangeException(nameof(breakType), breakType, null)
            };
        }
    }
}