using System;
using Sources.Game.Ecs.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Game.Ecs.DefaultComponents.Monos
{
    public class SafeRigidbody : MonoBehaviour, IRigidbody
    {
        [SerializeField]
        private Rigidbody _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        public float SignedSpeed => 
            LocalVelocity.z;

        public Vector3 Velocity
        {
            get => _rigidBody.velocity;
            set => _rigidBody.velocity = value;
        }

        public Vector3 LocalVelocity
        {
            get => _rigidBody.transform.InverseTransformDirection(_rigidBody.velocity);
            set => _rigidBody.velocity = _rigidBody.transform.TransformDirection(value);
        }

        public Vector3 Position
        {
            get => _rigidBody.position;
            set => _rigidBody.position = value;
        }

        public Quaternion Rotation
        {
            get => _rigidBody.rotation;
            set => _rigidBody.rotation = value;
        }
        
        public RigidbodyInterpolation Interpolation
        {
            get => _rigidBody.interpolation;
            set => _rigidBody.interpolation = value;
        }

        public bool DetectCollisions
        {
            get => _rigidBody.detectCollisions;
            set => _rigidBody.detectCollisions = value;
        }

        public bool IsKinematic
        {
            get => _rigidBody.isKinematic;
            set => _rigidBody.isKinematic = value;
        }

        public void MakeKinematic() =>
            _rigidBody.isKinematic = true;

        public void MakePhysical() =>
            _rigidBody.isKinematic = false;

        public void MoveRotation(Quaternion rotation) =>
            _rigidBody.MoveRotation(rotation);

        public Vector3 CenterMass
        {
            get => _rigidBody.centerOfMass;
            set => _rigidBody.centerOfMass = value;
        }

        public RigidbodyConstraints Constraints
        {
            get => _rigidBody.constraints;
            set => _rigidBody.constraints = value;
        }
        
        public float Mass
        {
            get => _rigidBody.mass;
            set => _rigidBody.mass = value;
        }
    }
}