using System;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views
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

        public float SignedSpeed => 
            transform.InverseTransformDirection(_rigidBody.velocity).z;

        public Vector3 Velocity
        {
            get => _rigidBody.velocity;
            set => _rigidBody.velocity = value;
        }
    }
}