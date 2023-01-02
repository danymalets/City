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

        public AudioClip Clip => _clip;
        public float Volume => _volume;
    }
}