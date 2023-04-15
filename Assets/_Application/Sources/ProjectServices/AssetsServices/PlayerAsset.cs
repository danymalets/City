using System;
using _Application.Sources.App.Data;
using Sources.Monos.MonoEntities;
using UnityEngine;

namespace Sources.ProjectServices.AssetsServices
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