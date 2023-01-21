using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Npc.NpcCar;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views.CarEngine;
using Sources.Game.Ecs.Components.Views.Physic;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcCarBreakRequestHandlerSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcCarBreakRequestHandlerSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, PlayerInCar, NpcOnPath, NpcCarBreakRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            float reqDistance = _simulationBalance.CarRootToForwardPoint + _simulationBalance.DistanceBetweenCars;
            
            foreach (Entity npcEntity in _filter)
            {
                Point breakPoint = npcEntity.Get<NpcCarBreakRequest>().Point;
                
                Entity carEntity = npcEntity.Get<PlayerInCar>().Car;

                //ITransform transform = npcEntity.GetMono<ITransform>();
                ICarWheels wheels = carEntity.GetMono<ICarWheels>();
                IPhysicBody physicBody = carEntity.GetMono<IPhysicBody>();
                CarMaxSpeed maxSpeed = carEntity.Get<CarMaxSpeed>();
                ref CarBreak carBreak = ref carEntity.Get<CarBreak>();
                ref CarMotorCoefficient carMotorCoefficient = ref carEntity.Get<CarMotorCoefficient>();

                float distance = Vector3.Distance(wheels.RootPosition, breakPoint.Position);

                //Debug.Log($"dist: {distance}");
                
                distance -= reqDistance;

                Debug.Log($"dist {distance} reqdist{reqDistance}");

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