using Sources.Utils.CommonUtils.Data;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    [RequireComponent(typeof(BoxCollider))]
    public class SafeBoxCollider : SafeCollider<BoxCollider>, ISafeBoxCollider
    {
        public BoxColliderData BoxColliderData => new BoxColliderData(
            transform.TransformPoint(_collider.center),
            _collider.size / 2,
            transform.rotation);

        public Vector3 LocalCenter => _collider.center;

        public Vector3 Center
        {
            get => _collider.center;
            set => _collider.center = value;
        }

        public Vector3 Size
        {
            get => _collider.size;
            set => _collider.size = value;
        }
    }
}