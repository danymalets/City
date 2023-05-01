using Sources.Utils.Di;

namespace Sources.Services.VibrationServices
{
    public interface IVibrationService : IService
    {
        void Vibrate();
    }
}