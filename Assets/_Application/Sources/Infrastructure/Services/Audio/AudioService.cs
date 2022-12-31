using System.Collections.Generic;
using Sources.Infrastructure.Services.Audio.Clips.Type;
using Sources.Infrastructure.Services.Audio.Data;
using Sources.Infrastructure.Services.Audio.Sounds;
using Sources.Infrastructure.Services.Pool;
using Sources.Infrastructure.Services.Pool.Instantiators;
using UnityEngine;

namespace Sources.Infrastructure.Services.Audio
{
    [RequireComponent(typeof(AudioData))]
    public class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField]
        private Sound _soundPrefab;

        private IPoolService _pool;
        private AudioData _audioData;

        private readonly HashSet<Sound> _playingSounds = new HashSet<Sound>();
        private IPoolInstantiatorService _poolInstantiator;

        public void Setup()
        {
            _audioData = GetComponent<AudioData>();
            
            _pool = DiContainer.Resolve<IPoolService>();
            _poolInstantiator = DiContainer.Resolve<IPoolInstantiatorService>();

            _pool.CreatePool(new PoolConfig(_soundPrefab, 20));
        }
        
        public void PlayOnce(SoundEffectType soundEffectType)
        {
            SoundEffectData soundEffectData = _audioData.GetSoundEffectData(soundEffectType);
            SetupSound(soundEffectData);
        }

        public void PlayMusic(MusicType musicType)
        {
            MusicData soundEffectData = _audioData.GetMusicData(musicType);
            SetupSound(soundEffectData);
        }

        public void StopAll()
        {
            foreach (Sound sound in _playingSounds)
            {
                if (sound.Stopable)
                    sound.Stop();
            }
        }

        private void SetupSound(SoundData soundData)
        {
            Sound sound = _poolInstantiator.Instantiate(_soundPrefab, transform);
            _playingSounds.Add(sound);
            sound.Setup(soundData, OnSoundPlayed);
        }

        private void OnSoundPlayed(Sound sound)
        {
            _playingSounds.Remove(sound);
            sound.Cleanup();
        }
    }
}