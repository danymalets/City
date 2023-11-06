using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.NpcCar
{
    public class CarForwardColliderGizmosSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public CarForwardColliderGizmosSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>()
                .SimulationBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<CarTag>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            // foreach (Entity carEntity in _filter)
            // {
            //     ref CheckForwardTriggerRequest checkForwardTriggerRequest = ref carEntity.Get<CheckForwardTriggerRequest>();
            //     
            //     _updateGizmosContext.DrawCube(
            //         checkForwardTriggerRequest.Center, checkForwardTriggerRequest.Rotation, checkForwardTriggerRequest.Size, Color.red);
            // }
        }
    }
}