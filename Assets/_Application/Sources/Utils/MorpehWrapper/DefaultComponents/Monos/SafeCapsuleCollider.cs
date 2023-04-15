using _Application.Sources.Utils.CommonUtils.Data;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class SafeCapsuleCollider : SafeCollider<CapsuleCollider>, ISafeMeshCollider
    {
        public CapsuleData CapsuleData => new CapsuleData(Start, End, Radius);

        public Vector3 Start => Center - Vector3.down * StartEndDistance / 2;
        public Vector3 End => Center + Vector3.down * StartEndDistance / 2;
        public Vector3 Center => _collider.center;
        public float Radius => _collider.radius;
        public float StartEndDistance => _collider.height - _collider.radius * 2;
    }
}