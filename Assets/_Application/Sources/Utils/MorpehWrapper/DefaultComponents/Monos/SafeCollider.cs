using UnityEngine;

namespace _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    public class SafeCollider<TCollider> : SafeColliderBase
        where TCollider : Collider
    {
        [SerializeField]
        protected TCollider _collider;
        
        public override bool IsTrigger
        {
            get => _collider.isTrigger;
            set => _collider.isTrigger = value;
        }

        public override Bounds Bounds => _collider.bounds;

        public override PhysicMaterial PhysicsMaterial
        {
            get => _collider.material;
            set => _collider.material = value;
        }

        private void OnValidate()
        {
            _collider = GetComponent<TCollider>();
        }
    }
}