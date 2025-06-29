using System;
using Sources.App.Services.AssetsServices.Common.MonoEntities.Player;
using Sources.App.Services.AssetsServices.Common.Players.PlayersData;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Players
{
    [Serializable]
    public class PlayerAsset
    {
        [SerializeField]
        private PlayerType _playerType;

        [SerializeField]
        private PlayerMonoEntity _playerPrefab;

        public PlayerAsset(PlayerType playerType)
        {
            _playerType = playerType;
        }

        public PlayerType PlayerType => _playerType;

        public PlayerMonoEntity PlayerPrefab => _playerPrefab;
    }
}