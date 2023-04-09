using Sources.Data.Players;
using Sources.Utils.DMorpeh;
using Sources.Utils.DMorpeh.DefaultComponents.Views;

namespace Sources.Data.MonoEntities
{
    public interface IPlayerMonoEntity : IMonoEntity
    {
        IEnableableGameObject EnableableGameObject { get; }
        IRigidbodySwitcher RigidbodySwitcher { get; }
        ITransform Transform { get; }
        IPlayerBorders PlayerBorders { get; }
        IAnimator Animator { get; }
    }
}