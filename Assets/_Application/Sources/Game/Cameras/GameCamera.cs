using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Cameras
{
    public class GameCamera : MonoBehaviour
    {
        public Camera Camera { get; private set; }

        [SerializeField]
        private Transform _target;

        [SerializeField]
        private Vector3 _offset = new Vector3(0, 5, -10);

        [SerializeField]
        private float _rotationY = -20;
        
        private void Awake()
        {
            Camera = GetComponent<Camera>();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void LateUpdate()
        {
            if (_target != null)
            {
                transform.position = _target.position + _target.TransformDirection(_offset);
                transform.LookAt(_target);
                transform.SetRotationX(_rotationY);
            }
        }
    }
}