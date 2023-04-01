using System;
using Sources.App.Game.Ecs.MonoEntities;
using Sources.App.Infrastructure.Services.AssetsManager;
using UnityEngine;

namespace Sources.App.Infrastructure.Services.Balance
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField]
        private PlayerType _playerType;

        [SerializeField]
        private PlayerMonoEntity _playerPrefab;

        public PlayerData(PlayerType playerType)
        {
            _playerType = playerType;
        }

        public PlayerType PlayerType => _playerType;

        public PlayerMonoEntity PlayerPrefab => _playerPrefab;
    }
}