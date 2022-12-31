using System;
using Sources.Infrastructure.Services.Audio.Clips.Type;
using Sources.Infrastructure.Services.Audio.Data;
using UnityEngine;

namespace Sources.Infrastructure.Services.Audio.Clips.Data
{
    [Serializable]
    public class MusicClipData
    {
        [SerializeField]
        private MusicType _musicType;
        
        [SerializeField]
        private MusicData _musicData;

        public MusicType MusicType => _musicType;
        public MusicData MusicData => _musicData;
    }
}