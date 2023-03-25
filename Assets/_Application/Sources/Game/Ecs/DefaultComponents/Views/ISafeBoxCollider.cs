using Sources.Game.Components.Old.CarCollider;
using UnityEngine;

namespace Sources.Game.Ecs.DefaultComponents.Views
{
    public interface ISafeBoxCollider
    {
        BoxColliderData BoxColliderData { get; }
        Vector3 LocalCenter { get; }
    }
}