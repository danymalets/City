using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Audio
{
    [Serializable]
    public class SoundEffectData
    {
        [HorizontalGroup("Main")]
        [SerializeField]
        private SoundType _type;

        [HorizontalGroup("Main")]

        [SerializeField]
        private AudioClip _clip;
        
        [HorizontalGroup("Main")]
        [Range(0f, 1f)]
        [SerializeField]
        private float _volume = 1f;
        
        [HorizontalGroup("Main")]
        [SerializeField]
        private bool _stopable = true;

        public SoundType Type => _type;
        public AudioClip Clip => _clip;
        public float Volume => _volume;
        public bool Stopable => _stopable;
    }
}