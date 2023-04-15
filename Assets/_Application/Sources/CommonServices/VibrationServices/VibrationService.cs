using _Application.Sources.Utils.CommonUtils.Data.Live;
using _Application.Sources.Utils.Di;
using Sources.ProjectServices.UserService;
using UnityEngine;

namespace Sources.CommonServices.VibrationServices
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