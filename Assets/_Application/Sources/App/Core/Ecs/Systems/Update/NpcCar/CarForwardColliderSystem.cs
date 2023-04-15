using _Application.Sources.App.Core.Ecs.Components.Car;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.Utils.CommonUtils.Data;
using _Application.Sources.Utils.CommonUtils.Extensions;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using Sources.ProjectServices.BalanceServices;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.NpcCar
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