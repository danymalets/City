using System;
using Sources.App.Data;
using UnityEngine;

namespace Sources.ProjectServices.BalanceServices
{
    [Serializable]
    public class PlayerBalance
    {
        [SerializeField]
        private PlayerType _playerType;

        [SerializeField]
        private float _weight = 100;

        public PlayerBalance(PlayerType playerType)
        {
            _playerType = playerType;
        }

        public PlayerType PlayerType => _playerType;
        public float Weight => _weight;
    }
}