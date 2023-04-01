using Sources.Data.Live;
using Sources.Di;
using Sources.Services.UserService;
using UnityEngine;

namespace Sources.Services.Vibration
{
    public class VibrationService : IVibrationService
    {
        private readonly LiveBool _vibrationOn;

        public VibrationService()
        {
            _vibrationOn = DiContainer.Resolve<IUserAccessService>()
                .User.Preferences.VibrationsOn;
        }

        public void Vibrate()
        {
            if (_vibrationOn.Value)
                Handheld.Vibrate();
        }
    }
}