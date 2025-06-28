using System;
using Sources.App.Services.AssetsServices.Common.Monos.MonoEntities.Player;
using Sources.App.Services.AssetsServices.Common.Monos.Players;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Monos.AssetsData
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