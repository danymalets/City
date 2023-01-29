using System;
using System.Collections.Generic;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(PlayersBalance), fileName = nameof(PlayersBalance))]
    public class PlayersBalance : ScriptableObject
    {
        [SerializeField]
        private List<PlayerBalance> _playersBalance;

        private void OnValidate()
        {
            DValidate.AddRequired(_playersBalance,
                pb => pb.PlayerType,
                (pd, en) => pd.PlayerType = en);
        }

        public PlayerType GetRandomPlayerType() =>
            _playersBalance.GetRandomWithWeights(pb => pb.Weight).PlayerType;
    }
}