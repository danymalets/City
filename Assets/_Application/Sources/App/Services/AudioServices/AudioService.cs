using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.Audio;
using Sources.App.Services.UserServices;
using Sources.Services.GameLoopServices;
using Sources.Services.InstantiatorServices;
using Sources.Services.PoolServices;
using Sources.Utils.CommonUtils.Utils;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.AudioServices
{
    public class AudioService : IInitializable, IAudioService
    {
        private static class Parameters
        {
            public const string SoundsVolume = "SoundsVolume";
            public const string MusicsVolume = "MusicsVolume";
        }
        
        private const float MinVolume = -80f;
        private const float MaxVolume = 0f;
        
        private readonly IPoolCreatorService _poolCreator;
        private readonly AudioAssets _audioAssets;
        
        private Dictionary<MusicType, MusicData> _musics = new();
        private Dictionary<SoundType, SoundEffectData> _soundEffects = new();
        private readonly HashSet<AudioSourceController> _playingSounds = new (10);
        private AudioSourceView _audioSourceViewPrefab;
        private readonly Transform _instancesRoot;
        private readonly IGameLoopService _gameLoopService;

        public AudioService(Transform root)
        {
            _instancesRoot = root;
            
            _audioAssets = DiContainer.Resolve<Assets>().AudioAssets;

            _poolCreator = DiContainer.Resolve<IPoolCreatorService>();
            _gameLoopService = DiContainer.Resolve<IGameLoopService>();
        }

        public void Initialize()
        {
            _audioSourceViewPrefab = _audioAssets.AudioSourceViewPrefab;

            _poolCreator.CreatePool(new PoolConfig(_audioSourceViewPrefab, 10));
            _musics = _audioAssets.MusicData.ToDictionary(e => e.Type, e => e);
            _soundEffects = _audioAssets.SoundEffectData.ToDictionary(e => e.Type, e => e);
            
            var userPreferences = DiContainer.Resolve<IUserAccessService>().User.UserPreferences;
            SetSoundsGroupVolume(userPreferences.SoundsVolume);
            SetMusicsGroupVolume(userPreferences.MusicVolume);

            _gameLoopService.RunEachFrame(OnUpdate);
        }

        public void SetSoundsGroupVolume(float volume)
        {
            SetMixerFloat(Parameters.SoundsVolume, volume);
        }

        public void SetMusicsGroupVolume(float volume)
        {
            SetMixerFloat(Parameters.MusicsVolume, volume);
        }

        private void SetMixerFloat(string parameterName, float volume)
        {
            _audioAssets.MasterMixerGroup.audioMixer.SetFloat(parameterName, Mathf.Lerp(MinVolume, MaxVolume, Mathf.Pow(volume, 1f/12f)));
        }

        public void PlayOnce(SoundType soundType)
        {
            var data = _soundEffects[soundType];
            SetupSound(new SoundSourceData(_audioAssets.SoundsMixerGroup, data.Clip, data.Volume, false, data.Stopable));
        }

        public void PlayMusic(MusicType musicType)
        {
            var data = _musics[musicType];
            SetupSound(new SoundSourceData(_audioAssets.MusicsMixerGroup, data.Clip, data.Volume, true, true));
        }

        public void StopAll()
        {
            foreach (var playingSound in _playingSounds)
            {
                playingSound.TryStop();
            }
        }

        private void OnUpdate()
        {
            foreach (var playingSound in _playingSounds.ToArray())
            {
                if (playingSound.TryCleanup())
                {
                    _playingSounds.Remove(playingSound);
                }
            }
        }

        private void SetupSound(SoundSourceData data)
        {
            var soundSourceController = new AudioSourceController(data, _instancesRoot);
            soundSourceController.Play();
            _playingSounds.Add(soundSourceController);
        }
    }
}