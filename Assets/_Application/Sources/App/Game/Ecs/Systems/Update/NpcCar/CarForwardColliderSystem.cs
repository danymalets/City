using Scellecs.Morpeh;
using Sources.App.Game.Components.Monos;
using Sources.App.Game.Components.Old;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Balance;
using Sources.Di;
using Sources.DMorpeh.DefaultComponents.Monos;
using Sources.DMorpeh.DefaultComponents.Views;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.NpcCar
{
    public class CarForwardColliderSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public CarForwardColliderSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance.Balance>()
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