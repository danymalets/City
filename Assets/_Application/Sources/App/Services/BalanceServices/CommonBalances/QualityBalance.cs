using System.Collections.Generic;
using System.Linq;
using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.Utils.CommonUtils.Utils;
using UnityEngine;

namespace Sources.App.Services.BalanceServices.CommonBalances
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(QualityBalance), fileName = nameof(QualityBalance))]
    public class QualityBalance : ScriptableObject
    {
        [field: SerializeField] public List<GameQualitySettings> GameQualitySettings = new();

        public GameQualitySettings Get(QualityType qualityType) =>
            GameQualitySettings.First(qs => qs.QualityType == qualityType);
    }
}