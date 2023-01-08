using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
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
                float maxSpeed = carEntity.Get<MaxSpeed>().Value;

                physicBody.Velocity = Vector3.ClampMagnitude(physicBody.Velocity, maxSpeed);
            }
        }
    }
}