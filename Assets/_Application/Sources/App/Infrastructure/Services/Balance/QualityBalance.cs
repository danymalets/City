using System.Collections.Generic;
using System.Linq;
using Sources.App.Infrastructure.Services.AssetsManager;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.App.Infrastructure.Services.Balance
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(QualityBalance), fileName = nameof(QualityBalance))]
    public class QualityBalance : ScriptableObject
    {
        [field: SerializeField]
        public List<GameQualitySettings> GameQualitySettings = new();

        private void OnValidate()
        {
            DValidate.OptimizeEnumsData(GameQualitySettings, 
                s => s.QualityType, qt => new GameQualitySettings(qt));
        }

        public GameQualitySettings Get(QualityType qualityType) =>
            GameQualitySettings.First(qs => qs.QualityType == qualityType);
    }
}