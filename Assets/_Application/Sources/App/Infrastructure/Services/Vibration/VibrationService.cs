using Sources.App.Infrastructure.Services.User;
using Sources.Data.Live;
using UnityEngine;

namespace Sources.App.Infrastructure.Services.Vibration
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