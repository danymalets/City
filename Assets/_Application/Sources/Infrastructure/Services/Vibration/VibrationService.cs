using Sources.Data;
using Sources.Data.Live;
using UnityEngine;

namespace Sources.Infrastructure.Services.Vibration
{
    public class VibrationService : IVibrationService
    {
        private readonly LiveBool _vibrationEnabled;

        public VibrationService()
        {
            _vibrationEnabled = Prefs.VibrationEnabled;
        }

        public void Vibrate()
        {
            if (_vibrationEnabled.Value)
                Handheld.Vibrate();
        }
    }
}