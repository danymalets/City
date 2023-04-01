using Sources.Services.Di;

namespace Sources.Services.Vibration
{
    public interface IVibrationService : IService
    {
        void Vibrate();
    }
}