using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Common;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Props
{
    public class PropsRigidbodyDisableSystem : DUpdateSystem
    {
        private Filter _filter;
        private Filter _userFilter;
        private readonly CommonBalance _commonBalance;

        public PropsRigidbodyDisableSystem()
        {
            _commonBalance = DiContainer.Resolve<Balance>().CommonBalance;
        }

        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag>();
            _filter = _world.Filter<PropsTag, Ref<IRigidbody>>().Without<FallingProps>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Vector3 userPosition = _userFilter.GetSingleton()
                .GetAspect<PlayerPointAspect>().GetPosition();

            float sqrDisableDistance = DMath.Sqr(_commonBalance.PropsRigidbodyDisableDistance);

            foreach (Entity propsEntity in _filter)
            {
                IRigidbody rigidbody = propsEntity.GetRef<IRigidbody>();
                Vector3 position = propsEntity.GetRef<ITransform>().Position;

                if (DVector3.SqrDistance(userPosition, position) > sqrDisableDistance &&
                    rigidbody.Velocity == Vector3.zero)
                {
                    SwitchableRigidbodyAspect switchableRigidbodyAspect = propsEntity.GetAspect<SwitchableRigidbodyAspect>();
                    switchableRigidbodyAspect.DisableRigidbody();
                }
            }
        }
    }
}