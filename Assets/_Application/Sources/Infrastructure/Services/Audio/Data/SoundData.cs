using System;
using Sources.Data.Live;
using UnityEngine;

namespace Sources.Infrastructure.Services.Audio.Data
{
    [Serializable]
    public abstract class SoundData
    {
        [SerializeField]
        private AudioClip _clip;
        
        [Range(0f, 1f)]
        [SerializeField]
        private float _volume = 1f;

        public abstract LiveBool EnabledLiveBool { get; }
        public AudioClip Clip => _clip;
        public abstract bool Loop { get; }
        public float Volume => _volume;
        
        public abstract bool Stopable { get; }
    }
}