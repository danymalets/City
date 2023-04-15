using System;
using _Application.Sources.App.Core.Ecs.Components.Car;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Car
{
    public class CarBreakApplySystem : DUpdateSystem
    {
        private const float BreakTorqueLite = 1.5f;
        private const float BreakTorqueMax = 1_000_000_000f;
        
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<CarTag>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                AxleInfo[] axleInfos = carEntity.GetAccess<IWheelsSystem>().AxleInfo;
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