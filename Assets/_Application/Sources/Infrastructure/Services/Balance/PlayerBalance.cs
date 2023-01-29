using System;
using Sources.Infrastructure.Services.AssetsManager;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [Serializable]
    public class PlayerBalance
    {
        public PlayerType PlayerType;

        [SerializeField]
        private float _weight = 100;

        public float Weight => _weight;
    }
}