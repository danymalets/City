using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.CarEngine;
using Sources.Game.Ecs.Components.Views.Physic;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcCarBreakPoint : DUpdateSystem
    {
        private Vector3 target = new(-23.72f + 1000f,0,-55.5f);
        private float breakDistance = 1.5f;
        
        
        private Filter _filter;
        private readonly IPhysicsService _physics;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                Entity carEntity = npcEntity.Get<PlayerInCar>().Car;
                
                //ITransform transform = npcEntity.GetMono<ITransform>();
                ICarWheels wheels = carEntity.GetMono<ICarWheels>();
                IPhysicBody physicBody = carEntity.GetMono<IPhysicBody>();
                CarMaxSpeed maxSpeed = carEntity.Get<CarMaxSpeed>();
                ref CarBreak carBreak = ref carEntity.Get<CarBreak>();
                ref CarMotorCoefficient carMotorCoefficient = ref carEntity.Get<CarMotorCoefficient>();

                float distance = Vector3.Distance(wheels.RootPosition, target);

                //Debug.Log($"dist: {distance}");
                
                distance -= 0.1f;

                if (distance < 0)
                {
                    carBreak.BreakType = BreakType.Max;
                }
                else if (distance < breakDistance)
                {
                    float progress = distance / breakDistance;
                    float mxSpeed = maxSpeed.Value * progress;

                    Debug.Log($"progress {progress} cur speed {physicBody.SignedSpeed} max speed {mxSpeed}");
                    
                    if (physicBody.SignedSpeed > mxSpeed)
                    {
                        Debug.Log($"break");
                        carBreak.BreakType = BreakType.Max;
                        carMotorCoefficient.Coefficient = 0;
                    }
                }
            }
        }
    }
}