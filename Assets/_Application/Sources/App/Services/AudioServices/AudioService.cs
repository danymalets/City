using System.Collections.Generic;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.Services.PoolServices;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.App.Services.AudioServices
{
    [RequireComponent(typeof(AudioData))]
    public class AudioService : MonoBehaviour, IInitializable, IAudioService
    {
        [FormerlySerializedAs("_soundPrefab")]
        [SerializeField]
        private SoundSource _soundSourcePrefab;

        private IPoolCreatorService _poolCreator;
        private AudioData _audioData;

        private readonly HashSet<SoundSource> _playingSounds = new (10);
        private IPoolSpawnerService _poolSpawner;
        private Preferences _preferences;

        public void Initialize()
        {
            _audioData = GetComponent<AudioData>();
            
            _poolCreator = DiContainer.Resolve<IPoolCreatorService>();
            _poolSpawner = DiContainer.Resolve<IPoolSpawnerService>();
            _preferences = DiContainer.Resolve<IUserAccessService>()
                .User.Preferences;

            _poolCreator.CreatePool(new PoolConfig(_soundSourcePrefab, 20));
        }
        
        public void PlayOnce(SoundEffectType soundEffectType)
        {
            SoundEffectData data = _audioData.GetSoundEffectData(soundEffectType);
            SetupSound(new SoundSourceData(data.Clip, data.Volume, false, _preferences.SoundsOn, data.Stopable));
        }

        public void PlayMusic(MusicType musicType)
        {
            MusicData data = _audioData.GetMusicData(musicType);
            SetupSound(new SoundSourceData(data.Clip, data.Volume, false, _preferences.SoundsOn, true));
        }

        public void StopAll()
        {
            foreach (SoundSource sound in _playingSounds)
            {
                if (sound.Stopable)
                    sound.Stop();
            }
        }

        private void SetupSound(SoundSourceData soundSourceData)
        {
            SoundSource soundSource = _poolSpawner.Spawn(_soundSourcePrefab, transform);
            _playingSounds.Add(soundSource);
            soundSource.Setup(soundSourceData, OnSoundPlayed);
        }

        private void OnSoundPlayed(SoundSource soundSource)
        {
            _playingSounds.Remove(soundSource);
        }
    }
}