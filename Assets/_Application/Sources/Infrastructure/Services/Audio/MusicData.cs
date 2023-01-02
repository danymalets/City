using System;
using Sources.Data;
using Sources.Data.Live;
using Sources.Infrastructure.Services.Audio.Clips.Type;
using UnityEngine;

namespace Sources.Infrastructure.Services.Audio.Data
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