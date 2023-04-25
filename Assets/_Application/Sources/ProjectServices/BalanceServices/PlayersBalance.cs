using System.Collections.Generic;
using Sources.App.Data;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.ProjectServices.BalanceServices
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(PlayersBalance), fileName = nameof(PlayersBalance))]
    public class PlayersBalance : ScriptableObject
    {
        [field: SerializeField] public float MinImpulseForFall { get; private set; } = 200;
        [field: SerializeField] public float UserMaxSpeed { get; private set; } = 3;
        [field: SerializeField] public float UserMaxRotationSpeed { get; private set; } = 90;
        [field: SerializeField] public float UserNavPathRotationSpeed { get; private set; } = 90;
        [field: SerializeField] public float NpcMaxRotationSpeed { get; private set; } = 90;
        [field: SerializeField] public float Mass { get; private set; } = 70;
        [field: SerializeField] public float Acceleration { get; private set; } = 6;
        [field: SerializeField] public float AllowableMoveAngle { get; private set; } = 30;

        [SerializeField]
        private List<PlayerBalance> _playersBalance;

        private void OnValidate()
        {
            DValidate.OptimizeEnumsData(_playersBalance,
                pb => pb.PlayerType,
                pb => new PlayerBalance(pb));
        }
        
        public PlayerType GetRandomPlayerType() =>
            _playersBalance.GetRandomWithWeights(pb => pb.Weight).PlayerType;
    }
}