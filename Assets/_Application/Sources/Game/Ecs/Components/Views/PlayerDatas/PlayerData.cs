using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Game.Ecs.Components.Views.PlayerDatas
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerData : MonoBehaviour, IPlayerData
    {
        [SerializeField]
        private float _speed = 3f;

        [SerializeField]
        private float _maxRotationSpeed = 180f;
        
        [SerializeField]
        private float _mass = 80f;

        public float Mass => _mass;
        public float Speed => _speed;
        public float MaxRotationSpeed => _maxRotationSpeed;

        private void OnValidate()
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            rigidbody.mass = _mass;

            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ |
                                    RigidbodyConstraints.FreezePositionY;
            
            rigidbody.angularDrag = 1f;
        }
    }
}