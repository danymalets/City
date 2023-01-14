using System;
using UnityEngine;

namespace Sources.Infrastructure.Services.Audio
{
    [Serializable]
    public class MusicData
    {
        [SerializeField]
        private MusicType _type;

        [SerializeField]
        private AudioClip _clip;
        
        [Range(0f, 1f)]
        [SerializeField]
        private float _volume = 1f;

        public MusicType Type => _type;
        public AudioClip Clip => _clip;
        public float Volume => _volume;
    }
}