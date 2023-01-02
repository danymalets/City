using Sources.Data.Live;
using UnityEngine;

namespace Sources.Infrastructure.Services.Audio
{
    public class SoundSourceData
    {
        public AudioClip AudioClip { get; }
        public float Volume { get; }
        public bool Loop { get; }
        public LiveBool SoundsEnabled { get; }
        public bool Stopable { get; }

        public SoundSourceData(AudioClip audioClip, float volume, bool loop, LiveBool soundsEnabled, bool stopable)
        {
            AudioClip = audioClip;
            Volume = volume;
            Loop = loop;
            SoundsEnabled = soundsEnabled;
            Stopable = stopable;
        }
    }
}