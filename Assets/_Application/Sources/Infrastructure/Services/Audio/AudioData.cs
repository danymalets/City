using System.Collections.Generic;
using Sources.Infrastructure.Services.Audio.Clips.Data;
using Sources.Infrastructure.Services.Audio.Clips.Type;
using Sources.Infrastructure.Services.Audio.Data;
using UnityEngine;

namespace Sources.Infrastructure.Services.Audio
{
    public class AudioData : MonoBehaviour
    {
        [SerializeField]
        private MusicClipData[] _musicClipData;

        [Space(30)]
        
        [SerializeField]
        private SoundEffectClipData[] _soundEffectClipData;

        private readonly Dictionary<SoundEffectType, SoundEffectData> _soundEffectData =
            new Dictionary<SoundEffectType, SoundEffectData>();
        
        private readonly Dictionary<MusicType, MusicData> _musicData =
            new Dictionary<MusicType, MusicData>();

        private void Awake()
        {
            foreach (SoundEffectClipData soundEffectClipData in _soundEffectClipData)
            {
                _soundEffectData.Add(
                    soundEffectClipData.SoundEffectType,
                    soundEffectClipData.SoundEffectData);
            }
            
            foreach (MusicClipData musicClipData in _musicClipData)
            {
                _musicData.Add(
                    musicClipData.MusicType,
                    musicClipData.MusicData);
            }
        }

        public SoundEffectData GetSoundEffectData(SoundEffectType soundEffectType) =>
            _soundEffectData[soundEffectType];

        public MusicData GetMusicData(MusicType musicType) =>
            _musicData[musicType];
    }
}