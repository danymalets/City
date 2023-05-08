using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Car
{
    public class IdleCarEnableRigidbodySystem : DUpdateSystem
    {
        private readonly CarsBalance _carsBalance;

        private Filter _carsFilter;
        private Filter _userFilter;

        public IdleCarEnableRigidbodySystem()
        {
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
        }

        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag>();
            _carsFilter = _world.Filter<CarTag, Idle>().Without<Ref<IRigidbody>>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            Vector3 userPosition = _userFilter.GetSingleton()
                .GetAspect<PlayerPointAspect>().GetPosition();

            float minSqrDistance = DMath.Sqr(_carsBalance.EnableIdleCarRigidBodyDistance);

            foreach (Entity carEntity in _carsFilter)
            {
                ITransform transform = carEntity.GetRef<ITransform>();

                if (DVector3.SqrDistance(userPosition, transform.Position) < minSqrDistance)
                {
                    SwitchableRigidbodyAspect rigidbodySwitcher = carEntity.GetAspect<SwitchableRigidbodyAspect>();
                    rigidbodySwitcher.EnableRigidbody();
                }
            }
        }
    }
}