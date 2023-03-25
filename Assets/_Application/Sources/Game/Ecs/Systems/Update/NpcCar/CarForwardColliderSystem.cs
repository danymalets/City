using Scellecs.Morpeh;
using Sources.Game.Components.Old.CarCollider;
using Sources.Game.Components.Views;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents;
using Sources.Game.Ecs.DefaultComponents.Monos;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.NpcCar
{
    public class CarForwardColliderSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public CarForwardColliderSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>()
                .SimulationBalance;
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<CarTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                ref ForwardTrigger forwardTrigger = ref carEntity.Get<ForwardTrigger>();
                ref SmoothSteeringAngle steeringAngle = ref carEntity.Get<SmoothSteeringAngle>();
                ITransform transform = carEntity.GetAccess<ITransform>();
                IWheelsSystem wheels = carEntity.GetAccess<IWheelsSystem>();
                SafeBoxCollider safeBoxCollider = carEntity.GetAccess<ICarBorders>().SafeBoxCollider;
                
                BoxColliderData borders = safeBoxCollider.BoxColliderData;
                
                float rootToForwardDistance = safeBoxCollider
                    .LocalCenter.z + borders.HalfExtents.z - wheels.RootOffset.z;

                Quaternion triggerRotation = transform.Rotation.WithIncreasedEulerY(steeringAngle.Value);

                Vector3 triggerCenter = wheels.RootPosition + triggerRotation * Vector3.forward * 
                    (rootToForwardDistance + _simulationBalance.CarTriggerLength / 2);

                forwardTrigger.Center = triggerCenter;
                forwardTrigger.Rotation = triggerRotation;
                forwardTrigger.Size = new Vector3(
                    borders.HalfExtents.x * 2, borders.HalfExtents.y * 2, _simulationBalance.CarTriggerLength );
                
                _updateGizmosContext.DrawCube(
                    forwardTrigger.Center, forwardTrigger.Rotation, forwardTrigger.Size, Color.red);
            }
        }
    }
}