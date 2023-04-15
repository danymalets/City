using Sources.Utils.DMorpeh.DefaultComponents.Monos;

namespace Sources.Utils.DMorpeh.DefaultComponents.Views
{
    public interface IRigidbodySwitcher
    {
        SafeRigidbody EnableRigidbody();
        void DisableRigidbody();
    }
}