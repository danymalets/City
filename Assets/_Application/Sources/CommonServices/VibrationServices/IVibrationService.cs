using Sources.Utils.Di;

namespace Sources.CommonServices.VibrationServices
{
    public interface IVibrationService : IService
    {
        void Vibrate();
    }
}