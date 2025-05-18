using Newtonsoft.Json;

namespace Sources.App.Services.UserServices.Users.PreferencesData
{
    public class UserPreferences
    {
        [JsonProperty] public float MusicVolume { get; set; } = 0.5f;
        [JsonProperty] public float SoundsVolume { get; set; } = 0.5f;
        [JsonProperty] public bool IsVibrationsOn { get; set; } = true;
        [JsonProperty] public LanguageType? SelectedLanguage { get; set; } = null;
        [JsonProperty] public QualityType? BestQualityForDevice { get; set; } = null;
        [JsonProperty] public QualityType SelectedQuality { get; set; } = QualityType.High;
    }
}