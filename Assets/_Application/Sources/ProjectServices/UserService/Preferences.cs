using Sources.App.Data;
using Sources.Utils.CommonUtils.Data.Live;

namespace Sources.ProjectServices.UserService
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