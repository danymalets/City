using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.CommonServices.PhysicsServices;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.NpcCar
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
                IWheelsSystem wheels = carEntity.GetAccess<IWheelsSystem>();
                IRigidbody physicBody = carEntity.GetAccess<IRigidbody>();
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