using Scellecs.Morpeh;
using Sources.App.Data.Cars;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.DefaultComponents;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;

namespace Sources.App.Core.Ecs.Aspects
{
    public struct SwitchableRigidbodyAspect : IDAspect
    {
        public Entity Entity { get; set; }

        public Filter GetFilter(Filter filter) => filter
            .With<Ref<IRigidbodySwitcher>, Ref<RigidbodySettings>>();

        public readonly IRigidbodySwitcher RigidbodySwitcher => Entity.GetRef<IRigidbodySwitcher>();
        public readonly RigidbodySettings RigidbodySettings => Entity.GetRef<RigidbodySettings>();

        public readonly bool HasPhysicBody() =>
            Entity.HasRef<IRigidbody>();

        public readonly SafeRigidbody EnableRigidbody()
        {
#if FORCE_DEBUG
            DAssert.IsTrue(!HasPhysicBody());
#endif
            
            SafeRigidbody safeRigidbody = RigidbodySwitcher.EnableRigidbodyInternal();
            RigidbodySettings rigidbodySettings = RigidbodySettings;
            
            safeRigidbody.Constraints = rigidbodySettings.RigidbodyConstraints;
            safeRigidbody.Mass = rigidbodySettings.Mass;
            if (rigidbodySettings.CenterOfMass != null)
                safeRigidbody.CenterMass = rigidbodySettings.CenterOfMass.Value;
            Entity.SetRef<IRigidbody>(safeRigidbody);

            if (Entity.TryGetRef(out IWheelsSystem wheelsSystem))
            {
                wheelsSystem.EnableSystem();
            }

            return safeRigidbody;
        }

        public readonly void DisableRigidbody()
        {
#if FORCE_DEBUG
            DAssert.IsTrue(HasPhysicBody());
#endif

            if (Entity.TryGetRef(out IWheelsSystem wheelsSystem))
            {
                wheelsSystem.DisableSystem();
            }

            RigidbodySwitcher.DisableRigidbodyInternal();
            Entity.RemoveRef<IRigidbody>();
        }

        public readonly void TryDisableRigidbody()
        {
            if (HasPhysicBody())
                DisableRigidbody();
        }
    }
}