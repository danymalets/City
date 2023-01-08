using Sources.Game.Ecs.Utils;

namespace Sources.Game.Ecs.Components.Views.PlayerAnimators
{
    public interface IPlayerAnimator : IMonoComponent
    {
        void SetIdle();
        void SetMove();
    }
}