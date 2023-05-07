using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    [RequireComponent(typeof(SphereCollider))]
    public class SafeSphereCollider : SafeCollider<SphereCollider>, ISafeSphereCollider
    {
        public Vector3 Center
        {
            get => _collider.center;
            set => _collider.center = value;
        }

        public float Radius
        {
            get => _collider.radius;
            set => _collider.radius = value;
        }
    }
}