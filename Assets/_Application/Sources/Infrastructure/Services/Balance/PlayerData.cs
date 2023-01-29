using System;
using Sources.Game.Ecs.MonoEntities;
using Sources.Infrastructure.Services.AssetsManager;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [Serializable]
    public class PlayerData
    {
        public PlayerType PlayerType;

        [SerializeField]
        private PlayerMonoEntity _playerPrefab;

        public PlayerMonoEntity PlayerPrefab => _playerPrefab;
    }
}