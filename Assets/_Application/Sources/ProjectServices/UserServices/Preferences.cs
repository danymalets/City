using Sources.ProjectServices.UserServices.Data;
using Sources.Utils.CommonUtils.Data.Live;

namespace Sources.ProjectServices.UserServices
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