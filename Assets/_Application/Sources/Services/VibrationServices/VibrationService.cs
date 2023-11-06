using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.Utils.CommonUtils.Data.Live;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.VibrationServices
{
    public class VibrationService : IVibrationService
    {
        private readonly UserPreferences _userPreferences;
        
        public VibrationService()
        {
             _userPreferences = DiContainer.Resolve<IUserAccessService>()
                .User.UserPreferences;
        }

        public void Vibrate()
        {
#if UNITY_IOS || UNITY_ANDROID
            if (_userPreferences.IsVibrationsOn)
                Handheld.Vibrate();
#endif
        }
    }
}