using System;
using Sources.App.Data.Players;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.App.Services.AssetsServices.Monos.MonoEntities.Player;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.AssetsData
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