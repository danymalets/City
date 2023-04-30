using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Views
{
    // не использовать напрямую, использовать SwitchableRigidbodyAspect вместо этого
    public interface IRigidbodySwitcher
    {
        SafeRigidbody EnableRigidbodyInternal();
        void DisableRigidbodyInternal();
    }
}