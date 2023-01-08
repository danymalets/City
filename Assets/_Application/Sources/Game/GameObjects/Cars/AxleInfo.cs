using System;
using Sources.Utilities.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Game.GameObjects.Cars
{
    [Serializable]
    public class AxleInfo
    {
        [SerializeField]
        private bool _motor;

        [Header("LeftWheel")]
        [SerializeField]
        private WheelCollider _leftWheelCollider;

        [SerializeField]
        private Transform _leftWheelGeometry;

        [Header("RightWheel")]
        [SerializeField]
        private WheelCollider _rightWheelCollider;

        [SerializeField]
        private Transform _rightWheelGeometry;

        public bool Motor => _motor;
        public WheelCollider LeftWheelCollider => _leftWheelCollider;
        public Transform LeftWheelGeometry => _leftWheelGeometry;
        public WheelCollider RightWheelCollider => _rightWheelCollider;
        public Transform RightWheelGeometry => _rightWheelGeometry;

        public Vector3 GetRoot() => ((LeftWheelCollider.transform.position +
                                      RightWheelCollider.transform.position) / 2).WithY(0);
    }
}