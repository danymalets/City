using Sources.DMorpeh.DefaultComponents.Monos;

namespace Sources.DMorpeh.DefaultComponents.Views
{
    public interface IRigidbodySwitcher
    {
        SafeRigidbody EnableRigidbody();
        void DisableRigidbody();
    }
}