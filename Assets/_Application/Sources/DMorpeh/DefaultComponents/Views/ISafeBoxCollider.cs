using Sources.App.Game.Components.Old;
using UnityEngine;

namespace Sources.DMorpeh.DefaultComponents.Views
{
    public interface ISafeBoxCollider
    {
        BoxColliderData BoxColliderData { get; }
        Vector3 LocalCenter { get; }
    }
}