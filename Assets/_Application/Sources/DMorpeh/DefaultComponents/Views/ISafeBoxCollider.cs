using _Application.Sources.Utils.Data;
using UnityEngine;

namespace Sources.DMorpeh.DefaultComponents.Views
{
    public interface ISafeBoxCollider
    {
        BoxColliderData BoxColliderData { get; }
        Vector3 LocalCenter { get; }
    }
}