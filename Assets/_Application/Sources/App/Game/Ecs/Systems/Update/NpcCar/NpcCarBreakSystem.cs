using _Application.Sources.MonoViews.MonoViews;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Npc.NpcCar;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Data.RoadSystem.Pathes.Points;
using Sources.Di;
using Sources.DMorpeh.DefaultComponents.Views;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Services.BalanceManager;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcCarBreakSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcCarBreakSystem()
        {
            _simulationBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().SimulationBalance;
        }

        protected override void OnConstruct()
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