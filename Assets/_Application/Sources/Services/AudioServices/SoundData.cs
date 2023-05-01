using System;
using UnityEngine;

namespace Sources.Services.AudioServices
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