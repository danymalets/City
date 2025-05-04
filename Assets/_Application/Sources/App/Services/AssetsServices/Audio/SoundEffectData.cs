using System;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Audio
{
    [Serializable]
    public class SoundEffectData
    {
        [SerializeField]
        private SoundType _type;

        [SerializeField]
        private AudioClip _clip;
        
        [Range(0f, 1f)]
        [SerializeField]
        private float _volume = 1f;
        
        [SerializeField]
        private bool _stopable = true;

        public SoundType Type => _type;
        public AudioClip Clip => _clip;
        public float Volume => _volume;
        public bool Stopable => _stopable;
    }
}