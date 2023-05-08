using Sources.App.Data.Players;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine.AI;

namespace Sources.App.Data.MonoEntities
{
    public interface IPlayerMonoEntity : IMonoEntity
    {
        IEnableableGameObject EnableableGameObject { get; }
        IRigidbodySwitcher RigidbodySwitcher { get; }
        ITransform Transform { get; }
        ITransform RootTransform { get; }
        IPlayerBorders PlayerBorders { get; }
        IAnimator Animator { get; }
        NavMeshObstacle NavMeshObstacle { get; }
    }
}