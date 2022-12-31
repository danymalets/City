using System;
using Sources.Data;
using Sources.Data.Live;
using UnityEngine;

namespace Sources.Infrastructure.Services.Audio.Data
{
    [Serializable]
    public class SoundEffectData : SoundData
    {
        [SerializeField]
        private bool _stopable = true;

        public override LiveBool EnabledLiveBool => Prefs.SoundEffectsEnabled;
        public override bool Loop => false;
        public override bool Stopable => _stopable;
    }
}