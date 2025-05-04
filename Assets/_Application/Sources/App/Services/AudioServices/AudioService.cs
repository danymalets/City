using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.Audio;
using Sources.Services.InstantiatorServices;
using Sources.Services.PoolServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.AudioServices
{
    public class AudioService : IInitializable, IAudioService
    {
        private readonly IPoolCreatorService _poolCreator;
        private readonly AudioAssets _audioAssets;
        
        private Dictionary<MusicType, MusicData> _musics = new();
        private Dictionary<SoundType, SoundEffectData> _soundEffects = new();
        private readonly HashSet<AudioSourceController> _playingSounds = new (10);
        private AudioSourceView _audioSourceViewPrefab;
        private readonly IGameObjectService _gameObjectService;
        private Transform _instancesRoot;

        public AudioService(Transform root)
        {
            _instancesRoot = root;
            
            _audioAssets = DiContainer.Resolve<Assets>().AudioAssets;

            _poolCreator = DiContainer.Resolve<IPoolCreatorService>();
            
            _gameObjectService = DiContainer.Resolve<IGameObjectService>();

            UpdateCycle().Forget();
        }

        public void Initialize()
        {
            _audioSourceViewPrefab = _audioAssets.AudioSourceViewPrefab;

            _poolCreator.CreatePool(new PoolConfig(_audioSourceViewPrefab, 10));
            _musics = _audioAssets.MusicData.ToDictionary(e => e.Type, e => e);
            _soundEffects = _audioAssets.SoundEffectData.ToDictionary(e => e.Type, e => e);
        }
        
        public void PlayOnce(SoundType soundType)
        {
            var data = _soundEffects[soundType];
            SetupSound(new SoundSourceData(data.Clip, data.Volume, false, data.Stopable));
        }

        public void PlayMusic(MusicType musicType)
        {
            var data = _musics[musicType];
            SetupSound(new SoundSourceData(data.Clip, data.Volume, true, true));
        }

        public void StopAll()
        {
            foreach (var playingSound in _playingSounds)
            {
                playingSound.TryStop();
            }
        }

        private async UniTask UpdateCycle()
        {
            while (true)
            {
                Update();
                await UniTask.NextFrame();
            }
        }

        private void Update()
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