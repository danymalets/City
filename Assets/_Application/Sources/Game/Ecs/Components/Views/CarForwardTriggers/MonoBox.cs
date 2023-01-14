using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarForwardTriggers
{
    public class MonoBox : MonoBehaviour, IMonoBox
    {
        [SerializeField]
        protected BoxCollider _boxCollider;

        public BoxCollider BoxCollider => _boxCollider;

        protected virtual void OnValidate()
        {
            if (_boxCollider != null)
            {
                _boxCollider.isTrigger = true;
            }
        }

        public Vector3 Center => 
            transform.TransformPoint(_boxCollider.center);

        public Vector3 HalfExtents =>
            _boxCollider.size / 2;

        public Quaternion Rotation =>
            transform.rotation;
    }
}