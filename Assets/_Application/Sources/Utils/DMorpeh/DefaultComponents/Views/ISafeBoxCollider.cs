using Sources.Utils.Data;
using UnityEngine;

namespace Sources.Utils.DMorpeh.DefaultComponents.Views
{
    public interface ISafeBoxCollider
    {
        BoxColliderData BoxColliderData { get; }
        Vector3 LocalCenter { get; }
    }
}