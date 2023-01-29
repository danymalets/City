using Sirenix.OdinInspector;
using Sources.Game.GameObjects.Cars;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarEngine
{
    [RequireComponent(typeof(Rigidbody))]
    public class CarWheels : MonoBehaviour, ICarWheels
    {
        [SerializeField]
        private AxleInfo[] _axleInfos;

        [SerializeField]
        [ReadOnly]
        private Vector3 _rootOffset;

        private Rigidbody _rigidBody;

        public Vector3 RootOffset => 
            _rootOffset;

        public AxleInfo[] AxleInfo =>
            _axleInfos;

        public Vector3 RootPosition => 
            transform.position + transform.rotation * _rootOffset;

        private void OnValidate()
        {
            if (_axleInfos != null && _axleInfos.Length > 0 &&
                _axleInfos[0].LeftWheelCollider != null &&
                _axleInfos[0].RightWheelCollider != null)
            {
                _rootOffset = _axleInfos[0].GetRoot();
            }
        }

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }
    }
}