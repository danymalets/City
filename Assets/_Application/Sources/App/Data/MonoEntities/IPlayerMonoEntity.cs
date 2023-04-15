using Sources.App.Data.Players;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;

namespace Sources.App.Data.MonoEntities
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