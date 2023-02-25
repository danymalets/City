using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.Physic
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicBody : MonoBehaviour, IPhysicBody
    {
        [SerializeField]
        private Rigidbody _rigidBody;
        
        private void OnValidate()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void Setup()
        {
            MakePhysical();
        }

        public void DestroyBody()
        {
            Destroy(_rigidBody);
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
            get => transform.InverseTransformDirection(_rigidBody.velocity);
            set => _rigidBody.velocity = transform.TransformDirection(value);
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
    }
}