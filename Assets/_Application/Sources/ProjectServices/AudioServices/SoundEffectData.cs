using System;
using UnityEngine;

namespace Sources.ProjectServices.AudioServices
{
    [Serializable]
    public class SoundEffectData
    {
        [SerializeField]
        private SoundEffectType _type;

        [SerializeField]
        private AudioClip _clip;
        
        [Range(0f, 1f)]
        [SerializeField]
        private float _volume = 1f;
        
        [SerializeField]
        private bool _stopable = true;

        public SoundEffectType Type => _type;
        public AudioClip Clip => _clip;
        public float Volume => _volume;
        public bool Stopable => _stopable;
    }
}