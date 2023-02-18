using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Game.Ecs.Components.Views.PlayerDatas
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerData : MonoBehaviour, IPlayerData
    {
        
        [SerializeField]
        private float _mass = 80f;

        public float Mass => _mass;

        private void OnValidate()
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            rigidbody.mass = _mass;

            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            
            rigidbody.angularDrag = 1f;
            
            rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        }
    }
}