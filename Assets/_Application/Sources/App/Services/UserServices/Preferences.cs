using Sources.App.Services.UserServices.Data;
using Sources.Utils.CommonUtils.Data.Live;

namespace Sources.App.Services.UserServices
{
    public class Preferences
    {
        public LiveBool MusicOn { get; private set; } = new (true);
        public LiveBool SoundsOn { get; private set; } = new (true);
        public LiveBool VibrationsOn { get; private set; } = new (true);
        public LanguageType? SelectedLanguage { get; set; } = null;
        public QualityType? BestQualityForDevice { get; set; } = null;
        public QualityType SelectedQuality { get; set; } = QualityType.High;
    }
}