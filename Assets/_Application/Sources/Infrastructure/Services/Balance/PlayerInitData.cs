using System;
using Sources.Game.Ecs.MonoEntities;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [Serializable]
    public class PlayerInitData
    {
        [SerializeField]
        private PlayerMonoEntity _playerPrefab;

        [SerializeField]
        private float _weight = 100;

        public PlayerMonoEntity PlayerPrefab => _playerPrefab;
        public float Weight => _weight;
    }
}