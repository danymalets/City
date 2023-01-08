using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.Cars;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class CarBreakApplySystem : DFixedUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<CarTag, CarBreak, Mono<ICarWheels>>();
        }

        protected override void OnFixedUpdate(float fixedDeltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                AxleInfo[] axleInfos = carEntity.GetMono<ICarWheels>().AxleInfo;
                float breakForce = carEntity.Get<CarBreak>().Break;

                for (int i = 0; i < axleInfos.Length; i++)
                {
                    AxleInfo axleInfo = axleInfos[i];
                    axleInfo.LeftWheelCollider.brakeTorque = breakForce * (i == 0 ? 70 : 30);
                    axleInfo.RightWheelCollider.brakeTorque = breakForce * (i == 0 ? 70 : 30);
                }
            }
            
            
        }
    }
}