using UnityEngine;

namespace Sources.App.Services.AudioServices
{
    public struct SoundSourceData
    {
        public AudioClip AudioClip { get; }
        public float Volume { get; }
        public bool IsLoop { get; }
        public bool IsStopable { get; }

        public SoundSourceData(AudioClip audioClip, float volume, bool isLoop, bool isStopable)
        {
            AudioClip = audioClip;
            Volume = volume;
            IsLoop = isLoop;
            IsStopable = isStopable;
        }
    }
}