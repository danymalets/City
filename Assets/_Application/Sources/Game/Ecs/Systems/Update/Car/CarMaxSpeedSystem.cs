using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.Data;
using Sources.Game.Ecs.Components.Views.Physic;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class CarMaxSpeedSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<CarTag>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                IPhysicBody physicBody = carEntity.GetMono<IPhysicBody>();
                float carMaxSpeed = carEntity.GetMono<ICarData>().MaxSpeed;
                float playerMaxSpeed = carEntity.Get<CarMaxSpeed>().Value;
                ref CarMotorCoefficient motorCoefficient = ref carEntity.Get<CarMotorCoefficient>();
                ref CarBreak carBreak = ref carEntity.Get<CarBreak>();

                float maxSpeed = Mathf.Min(carMaxSpeed, playerMaxSpeed);

                if (physicBody.SignedSpeed < 0)
                    maxSpeed /= 2;
                
                if (physicBody.Velocity.magnitude > maxSpeed)
                {
                    motorCoefficient.Coefficient = 0;
                }

                if (physicBody.Velocity.magnitude > maxSpeed + 0.5f)
                {
                    carBreak.BreakType = BreakType.Max;
                }
            }
        }
    }
}