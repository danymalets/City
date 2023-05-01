using System.Collections.Generic;
using UnityEngine;

namespace Sources.App.Services.AudioServices
{
    public class AudioData : MonoBehaviour
    {
        [SerializeField]
        private MusicData[] _musicData;

        [Space(30)]
        
        [SerializeField]
        private SoundEffectData[] _soundEffectData;

        private readonly Dictionary<MusicType, MusicData> _musicDictionary = new();
        
        private readonly Dictionary<SoundEffectType, SoundEffectData> _soundEffectDictionary = new();

        private void Awake()
        {
            foreach (MusicData musicData in _musicData)
            {
                _musicDictionary.Add(musicData.Type, musicData);
            }

            foreach (SoundEffectData soundEffectClipData in _soundEffectData)
            {
                _soundEffectDictionary.Add(soundEffectClipData.Type, soundEffectClipData);
            }
        }

        public SoundEffectData GetSoundEffectData(SoundEffectType soundEffectType) =>
            _soundEffectDictionary[soundEffectType];

        public MusicData GetMusicData(MusicType musicType) =>
            _musicDictionary[musicType];
    }
}