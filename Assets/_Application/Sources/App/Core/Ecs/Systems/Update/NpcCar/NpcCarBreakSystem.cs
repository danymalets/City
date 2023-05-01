using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Npc.NpcCar;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Data.Points;
using Sources.App.Services.BalanceServices;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.NpcCar
{
    public class NpcCarBreakSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcCarBreakSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, PlayerInCar, NpcOnPath, NpcCarBreakRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            float reqDistance = _simulationBalance.CarRootToForwardPoint + _simulationBalance.CarDistanceAfterBreak;
            
            foreach (Entity npcEntity in _filter)
            {
                Point breakPoint = npcEntity.Get<NpcCarBreakRequest>().Point;
                
                Entity carEntity = npcEntity.Get<PlayerInCar>().Car;

                //ITransform transform = npcEntity.GetMono<ITransform>();
                IWheelsSystem wheels = carEntity.GetAccess<IWheelsSystem>();
                IRigidbody physicBody = carEntity.GetAccess<IRigidbody>();
                CarMaxSpeed maxSpeed = carEntity.Get<CarMaxSpeed>();
                ref CarBreak carBreak = ref carEntity.Get<CarBreak>();
                ref CarMotorCoefficient carMotorCoefficient = ref carEntity.Get<CarMotorCoefficient>();

                float distance = Vector3.Distance(wheels.RootPosition, breakPoint.Position);

                //Debug.Log($"dist: {distance}");
                
                distance -= reqDistance;

                // Debug.Log($"dist {distance} reqdist{reqDistance}");

                if (distance < 0)
                {
                    carBreak.BreakType = BreakType.Max;
                    carMotorCoefficient.Coefficient = 0;
                }
                else if (distance < _simulationBalance.MaxBreakingDistance)
                {
                    float progress = distance / _simulationBalance.MaxBreakingDistance;
                    float mxSpeed = maxSpeed.Value * progress;

                    //Debug.Log($"progress {progress} cur speed {physicBody.SignedSpeed} max speed {mxSpeed}");
                    
                    if (physicBody.SignedSpeed > mxSpeed)
                    {
                        //Debug.Log($"break");
                        carBreak.BreakType = BreakType.Max;
                        carMotorCoefficient.Coefficient = 0;
                    }
                }
            }
        }
    }
}