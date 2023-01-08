using System;
using Sirenix.OdinInspector;
using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.Data
{
    [RequireComponent(typeof(Rigidbody))]
    public class CarData : MonoBehaviour, ICarData
    {
        [SerializeField]
        private float _mass = 1000;

        [SerializeField]
        private float _maxSpeed = 10;
        
        [SerializeField]
        private float _maxMotorTorque = 500;

        [SerializeField]
        private float _maxSteeringAngle = 45;

        [SerializeField]
        [ReadOnly]
        private Rigidbody _rigidBody;

        public float Mass => _mass;
        public float MaxSpeed => _maxSpeed;
        public float MaxMotorTorque => _maxMotorTorque;
        public float MaxSteeringAngle => _maxSteeringAngle;

        private void OnValidate()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _rigidBody.mass = _mass;
        }
    }

    public interface ICarData : IMonoComponent
    {
        float Mass { get; }
        float MaxSpeed { get; }
        float MaxMotorTorque { get; }
        float MaxSteeringAngle { get; }
    }
}