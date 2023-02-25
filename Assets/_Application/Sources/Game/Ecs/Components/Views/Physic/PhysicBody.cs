using System;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.Physic
{
    public class PhysicBody : MonoBehaviour, IPhysicBody
    {
        [SerializeField]
        private Rigidbody _rigidBody;

        private Vector3 _velocity;
        private UnityEngine.Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void Setup()
        {
            _velocity = Vector3.zero;
            DestroyBody();
        }

        private void OnValidate()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void DestroyBody()
        {
            if (_rigidBody != null)
            {
                Destroy(_rigidBody);
                _rigidBody = null;
            }
        }

        public float SignedSpeed =>
            LocalVelocity.z;

        public Vector3 Velocity
        {
            get => _rigidBody == null ? _velocity : _rigidBody.velocity;
            set
            {
                _velocity = value;
                if (_rigidBody != null)
                {
                    _rigidBody.velocity = _velocity;
                }
            }
        }

        public Vector3 LocalVelocity
        {
            get => transform.InverseTransformDirection(Velocity);
            set => Velocity = transform.TransformDirection(value);
        }

        public Vector3 Position
        {
            get => _rigidBody == null ? _rigidBody.position : transform.position;
            set => _rigidBody.position = value;
        }

        public Quaternion Rotation
        {
            get => _rigidBody.rotation;
            set => _rigidBody.rotation = value;
        }

        public void MoveRotation(Quaternion rotation)
        {
            if (_rigidBody == null)
                _transform.rotation = rotation;
            else
                _rigidBody.MoveRotation(rotation);
        }

        public Vector3 CenterMass
        {
            get => _rigidBody.centerOfMass;
            set => _rigidBody.centerOfMass = value;
        }
    }
}