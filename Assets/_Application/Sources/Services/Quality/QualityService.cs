using Sources.Balance;
using Sources.Di;
using Sources.Services.Times;
using Sources.User;
using UnityEngine;

namespace Sources.Services.Quality
{
    public class QualityService : IQualityAccessService, IQualityChangerService, IInitializable
    {
        private readonly Preferences _preferences;
        private readonly QualityBalance _qualityBalance;
        private readonly ITimeService _time;

        public GameQualitySettings GameQualitySettings { get; private set; }

        public QualityService()
        {
            _preferences = DiContainer.Resolve<IUserAccessService>().User.Preferences;
            _qualityBalance = DiContainer.Resolve<Balance.Balance>().QualityBalance;
            _time = DiContainer.Resolve<ITimeService>();
        }

        public void Initialize()
        {
            SetQuality(_preferences.SelectedQuality);
        }

        public void SetQuality(QualityType qualityType)
        {
            _preferences.SelectedQuality = qualityType;
            GameQualitySettings = _qualityBalance.Get(qualityType);
            SetQuality(GameQualitySettings);
        }

        public void SetQuality(GameQualitySettings qualitySettings)
        {
            QualitySettings.SetQualityLevel(qualitySettings.QualityLevelIndex);
            _time.PhysicsUpdateCount = qualitySettings.PhysicsUpdateCount;
        }
    }
}