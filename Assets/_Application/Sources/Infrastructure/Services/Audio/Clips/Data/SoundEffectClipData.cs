using System;
using Sources.Infrastructure.Services.Audio.Clips.Type;
using Sources.Infrastructure.Services.Audio.Data;
using UnityEngine;

namespace Sources.Infrastructure.Services.Audio.Clips.Data
{
    [Serializable]
    public class SoundEffectClipData
    {
        [SerializeField]
        private SoundEffectType _soundEffectType;

        [SerializeField]
        private SoundEffectData _soundEffectData;
        
        public SoundEffectType SoundEffectType => _soundEffectType;
        public SoundEffectData SoundEffectData => _soundEffectData;
    }
}