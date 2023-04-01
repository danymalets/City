using Scellecs.Morpeh;
using Sources.App.DMorpeh.Aspects;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.Game.Ecs.DefaultComponents;
using Sources.App.Game.Ecs.DefaultComponents.Monos;
using Sources.App.Game.Ecs.DefaultComponents.Views;

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
            return safeRigidbody;
        }
        
        public readonly void DisablePhysicBody()
        {
            RigidbodySwitcher.DisableRigidbody();
            Entity.RemoveAccess<IRigidbody>();
        }
    }
}