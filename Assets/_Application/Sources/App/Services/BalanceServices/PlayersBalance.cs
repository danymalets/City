using System.Collections.Generic;
using Sources.App.Data;
using Sources.App.Data.Players;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.App.Services.BalanceServices
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(PlayersBalance), fileName = nameof(PlayersBalance))]
    public class PlayersBalance : ScriptableObject
    {
        [field: SerializeField] public float MinImpulseForFall { get; private set; } = 200;
        [field: SerializeField] public float NpcOnPathMaxSpeed { get; private set; } = 1;
        [field: SerializeField] public float UserMaxSpeed { get; private set; } = 3;
        [field: SerializeField] public float UserMaxRotationSpeed { get; private set; } = 90;
        [field: SerializeField] public float NpcMaxRotationSpeed { get; private set; } = 90;
        [field: SerializeField] public float Mass { get; private set; } = 70;
        [field: SerializeField] public float Acceleration { get; private set; } = 6;
        [field: SerializeField] public float AllowableMoveAngle { get; private set; } = 0;
        [field: SerializeField] public float NavAllowableMoveAngle { get; private set; } = 45;
        [field: SerializeField] public float NavRotationSpeed { get; private set; } = 45;
        [field: SerializeField] public float DistanceToEnterCar { get; private set; } = 0.5f;
        
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