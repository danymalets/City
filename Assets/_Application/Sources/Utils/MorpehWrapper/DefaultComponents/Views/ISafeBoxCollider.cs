using _Application.Sources.Utils.CommonUtils.Data;
using UnityEngine;

namespace _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views
{
    public interface ISafeBoxCollider
    {
        BoxColliderData BoxColliderData { get; }
        Vector3 LocalCenter { get; }
    }
}