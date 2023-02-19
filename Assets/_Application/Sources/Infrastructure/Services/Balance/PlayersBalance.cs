using System;
using System.Collections.Generic;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Services.Balance
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(PlayersBalance), fileName = nameof(PlayersBalance))]
    public class PlayersBalance : ScriptableObject
    {
        [FormerlySerializedAs("_fallImpulse")]
        [SerializeField]
        private float _minImpulseForFall = 200;

        [SerializeField]
        private float _maxRotationSpeed = 45f;

        [field: SerializeField] public float UserMaxSpeed { get; private set; } = 3;

        [SerializeField]
        private List<PlayerBalance> _playersBalance;

        private void OnValidate()
        {
            DValidate.OptimizeEnumsData(_playersBalance,
                pb => pb.PlayerType,
                pb => new PlayerBalance(pb));
        }

        public float MinImpulseForFall => _minImpulseForFall;
        public float MaxRotationSpeed => _maxRotationSpeed;

        public PlayerType GetRandomPlayerType() =>
            _playersBalance.GetRandomWithWeights(pb => pb.Weight).PlayerType;
    }
}