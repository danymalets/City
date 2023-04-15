using Sources.Data;
using Sources.Utils.Data.Live;

namespace Sources.Services.UserService
{
    public class Preferences
    {
        public LiveBool MusicOn { get; private set; } = new (true);
        public LiveBool SoundsOn { get; private set; } = new (true);
        public LiveBool VibrationsOn { get; private set; } = new (true);
        
        public QualityType? BestQualityForDevice { get; set; } = null;
        public QualityType SelectedQuality { get; set; } = QualityType.Low;
    }
}