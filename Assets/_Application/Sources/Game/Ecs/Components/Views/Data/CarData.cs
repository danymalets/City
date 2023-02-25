using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.Data
{
    public class CarData : MonoBehaviour, ICarData
    {
        [SerializeField]
        private float _mass = 800;

        [SerializeField]
        private float _maxSpeed = 9;
        
        [SerializeField]
        private float _maxMotorTorque = 400;

        [SerializeField]
        private float _maxSteeringAngle = 45;

        public float Mass => _mass;
        public float MaxSpeed => _maxSpeed;
        public float MaxMotorTorque => _maxMotorTorque;
        public float MaxSteeringAngle => _maxSteeringAngle;

        private void OnValidate()
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.mass = _mass;
            rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        }
    }
}