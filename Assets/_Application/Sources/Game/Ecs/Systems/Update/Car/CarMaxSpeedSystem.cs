using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.Data;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class CarMaxSpeedSystem : DFixedUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<CarTag>();
        }

        protected override void OnFixedUpdate(float fixedDeltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                IPhysicBody physicBody = carEntity.GetMono<IPhysicBody>();
                float carMaxSpeed = carEntity.GetMono<ICarData>().MaxSpeed;
                float playerMaxSpeed = carEntity.Get<PlayerCarMaxSpeed>().Value;

                float maxSpeed = Mathf.Min(carMaxSpeed, playerMaxSpeed);

                if (physicBody.SignedSpeed < 0)
                    maxSpeed /= 2;
                
                physicBody.Velocity = Vector3.ClampMagnitude(physicBody.Velocity, maxSpeed);
            }
        }
    }
}