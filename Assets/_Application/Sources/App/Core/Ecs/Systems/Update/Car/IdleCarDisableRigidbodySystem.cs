using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Common;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.CarsBalances;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Car
{
    public class IdleCarDisableRigidbodySystem : DUpdateSystem
    {
        private readonly CarsBalance _carsBalance;

        private Filter _carsFilter;
        private Filter _userFilter;

        public IdleCarDisableRigidbodySystem()
        {
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
        }

        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag>().Build();
            _carsFilter = _world.Filter<CarTag, Idle, Ref<IRigidbody>>().Build();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            Vector3 userPosition = _userFilter.GetSingleton()
                .GetAspect<PlayerPointAspect>().GetPosition();

            float maxSqrDistance = DMath.Sqr(_carsBalance.DisableIdleCarRigidBodyDistance);

            foreach (Entity carEntity in _carsFilter)
            {
                ITransform transform = carEntity.GetRef<ITransform>();

                if (DVector3.SqrDistance(userPosition, transform.Position) > maxSqrDistance)
                {
                    SwitchableRigidbodyAspect rigidbodySwitcher = carEntity.GetAspect<SwitchableRigidbodyAspect>();
                    rigidbodySwitcher.DisableRigidbody();
                }
            }
        }
    }
}