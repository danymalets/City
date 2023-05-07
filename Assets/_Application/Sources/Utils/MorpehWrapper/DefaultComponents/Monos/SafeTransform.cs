using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    [RequireComponent(typeof(Transform))]
    public class SafeTransform : MonoBehaviour, ITransform
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        public Vector3 Position
        {
            get => _transform.position;
            set => _transform.position = value;
        }

        public Quaternion Rotation
        {
            get => _transform.rotation;
            set => _transform.rotation = value;
        }

        public Vector3 PointLocalToWorld(Vector3 point) => 
            _transform.TransformPoint(point);

        public Vector3 PointWorldToLocal(Vector3 point) => 
            _transform.InverseTransformPoint(point);
    }
}