using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Common;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Props;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Constants;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Props
{
    public class PropsFallSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly CommonBalance _commonBalance;

        public PropsFallSystem()
        {
            _commonBalance = DiContainer.Resolve<Balance>().CommonBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<VerticalPropsTag, Ref<IRigidbody>>().Without<FallingProps>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity propsEntity in _filter)
            {
                IRigidbody rigidbody = propsEntity.GetRef<IRigidbody>();

                Vector3 up = propsEntity.Get<VerticalPoint>().Point.Up;

                float angle = Vector3.Angle(up, Vector3.up);

                if (angle > _commonBalance.PropsAngleToFallenLayer &&
                    rigidbody.Velocity != Vector3.zero)
                {
                    rigidbody.ResetCenterOfMass();
                    propsEntity.Add<FallingProps>();
                    propsEntity.Set(new SetLayerRequest { Layer = Layers.Falling });
                }
            }
        }
    }
}