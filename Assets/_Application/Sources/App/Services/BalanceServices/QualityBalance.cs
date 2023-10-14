using System.Collections.Generic;
using System.Linq;
using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.App.Services.BalanceServices
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(QualityBalance), fileName = nameof(QualityBalance))]
    public class QualityBalance : ScriptableObject
    {
        [field: SerializeField] public List<GameQualitySettings> GameQualitySettings = new();

        private void OnValidate()
        {
            DValidate.ValidateEnumsData(GameQualitySettings, 
                s => s.QualityType, 
                qt => new GameQualitySettings(qt));
        }

        public GameQualitySettings Get(QualityType qualityType) =>
            GameQualitySettings.First(qs => qs.QualityType == qualityType);
    }
}