using Sources.Game.Ecs.DefaultComponents.Monos;

namespace Sources.Game.Ecs.DefaultComponents.Views
{
    public interface IRigidbodySwitcher
    {
        SafeRigidbody EnableRigidbody();
        void DisableRigidbody();
    }
}