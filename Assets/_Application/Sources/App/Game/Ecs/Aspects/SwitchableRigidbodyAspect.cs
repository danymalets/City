using Scellecs.Morpeh;
using Sources.Data.MonoViews.MonoViews;
using Sources.Utils.DMorpeh.Aspects;
using Sources.Utils.DMorpeh.DefaultComponents;
using Sources.Utils.DMorpeh.DefaultComponents.Monos;
using Sources.Utils.DMorpeh.DefaultComponents.Views;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using UnityEngine;

namespace Sources.App.Game.Ecs.Aspects
{
    public struct SwitchableRigidbodyAspect : IDAspect
    {
        public Entity Entity { get; set; }
        public readonly IRigidbodySwitcher RigidbodySwitcher => Entity.GetAccess<IRigidbodySwitcher>();
        public readonly RigidbodySettings RigidbodySettings => Entity.GetAccess<RigidbodySettings>();

        public readonly bool HasPhysicBody() =>
            Entity.HasAccess<IRigidbody>();

        public readonly SafeRigidbody EnablePhysicBody()
        {
            SafeRigidbody safeRigidbody = RigidbodySwitcher.EnableRigidbody();
            RigidbodySettings rigidbodySettings = RigidbodySettings;
            safeRigidbody.Mass = rigidbodySettings.Mass;
            safeRigidbody.Constraints = rigidbodySettings.RigidbodyConstraints;
            if (rigidbodySettings.CenterOfMass != null)
                safeRigidbody.CenterMass = rigidbodySettings.CenterOfMass.Value;
            Entity.SetAccess<IRigidbody>(safeRigidbody);

            if (Entity.TryGetAccess(out IWheelsSystem wheelsSystem))
            {
                wheelsSystem.EnableSystem();
            }

            return safeRigidbody;
        }

        public readonly void DisablePhysicBody()
        {
            if (Entity.TryGetAccess(out IWheelsSystem wheelsSystem))
                wheelsSystem.DisableSystem();
            RigidbodySwitcher.DisableRigidbody();
            Entity.RemoveAccess<IRigidbody>();
        }
    }
}