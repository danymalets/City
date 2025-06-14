using UnityEngine;
using UnityEngine.Audio;

namespace Sources.App.Services.AssetsServices.Audio
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(AudioAssets), fileName = nameof(AudioAssets))]
    public class AudioAssets : ScriptableObject
    {
        [field: SerializeField] public AudioMixerGroup MasterMixerGroup { get; private set; }
        [field: SerializeField] public AudioMixerGroup SoundsMixerGroup { get; private set; }
        [field: SerializeField] public AudioMixerGroup MusicsMixerGroup { get; private set; }
        [field: SerializeField] public AudioSourceView AudioSourceViewPrefab { get; private set; }
        [field: SerializeField] public MusicData[] MusicData { get; private set; }
        [field: SerializeField] public SoundEffectData[] SoundEffectData { get; private set; }
    }
}