using System;
using UnityEngine;

namespace _Application.Sources.App.Data.Cars
{
    [Serializable]
    public class AxleInfo
    {
        [SerializeField]
        private bool _motor = true;

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
                                      RightWheelCollider.transform.position) / 2) -
                                    LeftWheelCollider.transform.transform.up * LeftWheelCollider.radius;
    }
}