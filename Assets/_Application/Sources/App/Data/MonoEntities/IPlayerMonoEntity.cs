using _Application.Sources.App.Data.Players;
using _Application.Sources.Utils.MorpehWrapper;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;

namespace _Application.Sources.App.Data.MonoEntities
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