using System;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.PlayerDatas
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerData : MonoBehaviour, IPlayerData
    {
        [SerializeField]
        private float _speed = 3f;

        [SerializeField]
        private float _mass = 80f;

        public float Mass => _mass;
        public float Speed => _speed;

        private void OnValidate()
        {
            GetComponent<Rigidbody>().mass = _mass;
        }
    }
}