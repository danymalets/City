using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Data;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.NpcCar
{
    public class CarForwardColliderCalculateSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public CarForwardColliderCalculateSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, PlayerInCar, CheckForwardTriggerRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ref CheckForwardTriggerRequest checkForwardTriggerRequest = ref playerEntity.Get<CheckForwardTriggerRequest>();
                Entity carEntity = playerEntity.Get<PlayerInCar>().CarPlaceData.Car;
                ref SmoothSteeringAngle steeringAngle = ref carEntity.Get<SmoothSteeringAngle>();
                ITransform transform = carEntity.GetRef<ITransform>();
                IWheelsSystem wheels = carEntity.GetRef<IWheelsSystem>();
                SafeBoxCollider safeBoxCollider = carEntity.GetRef<ICarBorders>().SafeBoxCollider;
                
                BoxColliderData borders = safeBoxCollider.BoxColliderData;
                
                float rootToForwardDistance = safeBoxCollider
                    .LocalCenter.z + borders.HalfExtents.z - wheels.RootOffset.z;

                Quaternion triggerRotation = transform.Rotation.WithIncreasedEulerY(steeringAngle.Value);

                Vector3 triggerCenter = wheels.RootPosition + triggerRotation * Vector3.forward * 
                    (rootToForwardDistance + _simulationBalance.CarTriggerLength / 2) +
                    triggerRotation * Vector3.up * borders.HalfExtents.y;

                checkForwardTriggerRequest.Center = triggerCenter;
                checkForwardTriggerRequest.Rotation = triggerRotation;
                checkForwardTriggerRequest.Size = new Vector3(
                    borders.HalfExtents.x * 2, borders.HalfExtents.y * 2, _simulationBalance.CarTriggerLength );
            }
        }
    }
}