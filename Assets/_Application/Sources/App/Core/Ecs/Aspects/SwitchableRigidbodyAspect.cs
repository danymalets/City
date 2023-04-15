using _Application.Sources.App.Data.Cars;
using _Application.Sources.Utils.MorpehWrapper.Aspects;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Aspects
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