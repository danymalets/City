using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Monos;

namespace _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views
{
    public interface IRigidbodySwitcher
    {
        SafeRigidbody EnableRigidbody();
        void DisableRigidbody();
    }
}