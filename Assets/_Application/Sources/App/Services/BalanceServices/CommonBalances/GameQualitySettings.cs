using System;
using Sources.App.Services.UserServices.Users.PreferencesData;
using UnityEngine;

namespace Sources.App.Services.BalanceServices.CommonBalances
{
    [Serializable]
    public class GameQualitySettings
    {
        [field: SerializeField] public QualityType QualityType { get; private set; }
        [field: SerializeField] public int CarsPer1000SpawnPoints { get; private set; } = 100;
        [field: SerializeField] public int NpcsPer1000SpawnPoints { get; private set; } = 90;
        [field: SerializeField] public float NpcRadius { get; private set; } = 50;
        [field: SerializeField] public float BackDistance { get; private set; } = 20;
        [field: SerializeField] public int PhysicsUpdateCount { get; private set; } = 50;
        [field: SerializeField] public int QualityLevelIndex { get; private set; } = 0;

        public GameQualitySettings(QualityType qt)
        {
            QualityType = qt;
        }
    }
}