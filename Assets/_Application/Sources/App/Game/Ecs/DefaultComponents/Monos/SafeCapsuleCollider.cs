using Sources.App.Game.Components.Old;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Game.Ecs.DefaultComponents.Monos
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