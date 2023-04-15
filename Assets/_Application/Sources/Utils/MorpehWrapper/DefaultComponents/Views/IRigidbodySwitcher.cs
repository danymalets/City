using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Views
{
    public interface IRigidbodySwitcher
    {
        SafeRigidbody EnableRigidbody();
        void DisableRigidbody();
    }
}