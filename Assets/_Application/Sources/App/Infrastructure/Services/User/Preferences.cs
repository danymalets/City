using Sources.App.Infrastructure.Services.Balance;
using Sources.Data.Live;

namespace Sources.App.Infrastructure.Services.User
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