using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update
{
    public class PlayerCarMoveSystem : DUpdateSystem
    {
        private const float BreakTorqueLite = 1.5f;
        private const float BreakTorqueMax = 1_000_000_000f;
        
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<MoveInput, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ref MoveInput moveInput = ref playerEntity.Get<MoveInput>();
                
                Entity carEntity = playerEntity.Get<PlayerInCar>().Car;

                float signedSpeed = carEntity.GetMono<IPhysicBody>().SignedSpeed;

                carEntity.Set(new ChangeSteeringAngleRequest { AngleCoefficient = moveInput.Horizontal });

                float motorCoefficient = moveInput.Vertical;
                float breakForce;
                
                if (moveInput.Vertical == 1 && DMath.Less(signedSpeed, 0))
                {
                    breakForce = BreakTorqueMax;
                    motorCoefficient = 0;
                }
                else if (moveInput.Vertical == -1 && DMath.Greater(signedSpeed, 0))
                {
                    breakForce = BreakTorqueMax;
                    motorCoefficient = 0;
                }
                else if (moveInput.Vertical == 0)
                {
                    breakForce = BreakTorqueLite;
                }
                else
                {
                    breakForce = 0;
                }

                carEntity.Get<CarMotorCoefficient>().Coefficient = motorCoefficient;
                carEntity.Get<CarBreak>().Break = breakForce;
            }
        }
    }
}