using System.Linq;
using Sirenix.OdinInspector;
using Sources.Game.GameObjects.Cars;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views
{
    [RequireComponent(typeof(Rigidbody))]
    public class CarWheels : MonoBehaviour, ICarWheels
    {
        private const float BreakTorqueLite = 1.5f;
        private const float BreakTorqueMax = 1_000_000_000f;

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
            if (_axleInfos.Length > 0 &&
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