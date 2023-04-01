using Sources.App.Game.Ecs.DefaultComponents.Monos;

namespace Sources.App.Game.Ecs.DefaultComponents.Views
{
    public interface IRigidbodySwitcher
    {
        SafeRigidbody EnableRigidbody();
        void DisableRigidbody();
    }
}