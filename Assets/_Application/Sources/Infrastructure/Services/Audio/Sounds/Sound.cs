using System;
using Sources.Data.Live;
using Sources.Infrastructure.Services.Audio.Data;
using Sources.Infrastructure.Services.Pool;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Infrastructure.Services.Audio.Sounds
{
    public class Sound : RespawnableBehaviour
    {
        protected AudioSource _audioSource;
        private LiveBool _enabledLiveBool;
        public bool Stopable { get; private set; }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Setup(SoundData soundData, Action<Sound> played)
        {
            Stopable = soundData.Stopable;
            
            _enabledLiveBool = soundData.EnabledLiveBool;

            OnEnabledValueChanged(_enabledLiveBool.Value);
            _enabledLiveBool.Changed += OnEnabledValueChanged;
            
            _audioSource.clip = soundData.Clip;
            _audioSource.loop = soundData.Loop;
            _audioSource.volume = soundData.Volume;
            _audioSource.Play();

            this.RunWhen(() => !_audioSource.isPlaying, () => played(this));
        }

        public void Stop() =>
            _audioSource.Stop();
        
        public void Cleanup()
        {
            _enabledLiveBool.Changed -= OnEnabledValueChanged;
            Despawn();
        }
        
        private void OnEnabledValueChanged(bool enabled)
        {
            _audioSource.mute = !_enabledLiveBool.Value;
        }
    }
}