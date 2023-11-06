using Sources.Utils.CommonUtils.Data.Live;

namespace Sources.App.Services.UserServices.Users.PreferencesData
{
    public class UserPreferences
    {
        public float MusicVolume { get; set; } = 0.5f;
        public float SoundsVolume { get; set; } = 0.5f;
        public bool IsVibrationsOn { get; set; } = true;
        public LanguageType? SelectedLanguage { get; set; } = null;
        public QualityType? BestQualityForDevice { get; set; } = null;
        public QualityType SelectedQuality { get; set; } = QualityType.High;
    }
}