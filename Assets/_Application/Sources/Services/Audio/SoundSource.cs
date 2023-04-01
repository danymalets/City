using System;
using Sources.Services.Pool;
using Sources.Utils.Data.Live;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.Services.Audio
{
    public class SoundSource : RespawnableBehaviour
    {
        public bool Stopable { get; private set; }

        private AudioSource _audioSource;
        private LiveBool _soundEnabled;
        private Action<SoundSource> _onPlayed;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Setup(SoundSourceData data, Action<SoundSource> onPlayed)
        {
            Stopable = data.Stopable;
            
            _soundEnabled = data.SoundsEnabled;
            _onPlayed = onPlayed;
            
            OnEnabledValueChanged(_soundEnabled.Value);
            _soundEnabled.Changed += OnEnabledValueChanged;
            
            _audioSource.clip = data.AudioClip;
            _audioSource.loop = data.Loop;
            _audioSource.volume = data.Volume;
            
            _audioSource.Play();

            this.RunWhen(() => !_audioSource.isPlaying, Cleanup);
        }

        public void Stop() =>
            _audioSource.Stop();

        private void OnEnabledValueChanged(bool enabled) => 
            _audioSource.mute = !_soundEnabled.Value;

        public void Cleanup()
        {
            _soundEnabled.Changed -= OnEnabledValueChanged;
            Despawn();
            _onPlayed?.Invoke(this);
        }
    }
}