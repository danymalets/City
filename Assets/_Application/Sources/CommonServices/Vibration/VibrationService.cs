using Sources.Services.Di;
using Sources.Services.UserService;
using Sources.Utils.Data.Live;
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