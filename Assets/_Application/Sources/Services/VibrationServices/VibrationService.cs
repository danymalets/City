using Sources.App.Services.UserServices;
using Sources.Utils.CommonUtils.Data.Live;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.VibrationServices
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
#if UNITY_IOS || UNITY_ANDROID
            if (_vibrationOn.Value)
                Handheld.Vibrate();
#endif
        }
    }
}