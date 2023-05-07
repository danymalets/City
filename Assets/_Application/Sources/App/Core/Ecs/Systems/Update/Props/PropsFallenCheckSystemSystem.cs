using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Props;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Constants;
using Sources.App.Services.BalanceServices;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Props
{
    public class PropsFallenCheckSystemSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly CommonBalance _commonBalance;

        public PropsFallenCheckSystemSystem()
        {
            _commonBalance = DiContainer.Resolve<Balance>().CommonBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<VerticalPropsTag, FallingProps>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity propsEntity in _filter)
            {
                IRigidbody rigidbody = propsEntity.GetRef<IRigidbody>();

                if (rigidbody.Velocity == Vector3.zero)
                {
                    rigidbody.ResetCenterOfMass();
                    propsEntity.Remove<FallingProps>();
                    propsEntity.Add<FallenProps>();
                    SwitchableRigidbodyAspect switchableRigidbodyAspect = propsEntity.GetAspect<SwitchableRigidbodyAspect>();
                    switchableRigidbodyAspect.DisableRigidbody();
                }
            }
        }
    }
}