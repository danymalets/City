using Sources.Data.MonoViews.MonoViews;
using Sources.Services.Pool;
using Sources.Utils.DMorpeh;
using Sources.Utils.DMorpeh.DefaultComponents.Views;

namespace Sources.Data.MonoViews
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