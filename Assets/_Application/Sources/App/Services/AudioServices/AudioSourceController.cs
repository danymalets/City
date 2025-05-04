using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.Audio;
using Sources.Services.PoolServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.AudioServices
{
    public class AudioSourceController
    {
        private readonly IPoolSpawnerService _poolSpawner;
        private readonly IPoolDespawnerService _poolDespawner;
        private readonly Transform _instancesRoot;
        private readonly AudioSourceView _audioSourceViewPrefab;
        private readonly SoundSourceData _data;
        private AudioSourceView _audioSourceView;

        public AudioSourceController(SoundSourceData data, Transform instancesRoot)
        {
            _audioSourceViewPrefab = DiContainer.Resolve<Assets>().AudioAssets.AudioSourceViewPrefab;
            _poolSpawner = DiContainer.Resolve<IPoolSpawnerService>();
            _poolDespawner = DiContainer.Resolve<IPoolDespawnerService>();
            _data = data;
            _instancesRoot = instancesRoot;
        }

        public void Play()
        {
            _audioSourceView = _poolSpawner.Spawn(_audioSourceViewPrefab, _instancesRoot);

            var audioSource = _audioSourceView.AudioSource;
            
            audioSource.clip = _data.AudioClip;
            audioSource.volume = _data.Volume;
            audioSource.loop = _data.IsLoop;
            audioSource.Play();
        }

        public void TryStop()
        {
            if (_data.IsStopable)
            {
                _audioSourceView.AudioSource.Stop();
            }
        }

        public bool TryCleanup()
        {
            if (!_audioSourceView.AudioSource.isPlaying)
            {
                _poolDespawner.Despawn(_audioSourceView);
                return true;
            }

            return false;
        }
    }
}