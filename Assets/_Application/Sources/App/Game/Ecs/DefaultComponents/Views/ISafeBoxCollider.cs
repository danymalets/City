using Sources.App.Game.Components.Old;
using UnityEngine;

namespace Sources.App.Game.Ecs.DefaultComponents.Views
{
    public interface ISafeBoxCollider
    {
        BoxColliderData BoxColliderData { get; }
        Vector3 LocalCenter { get; }
    }
}