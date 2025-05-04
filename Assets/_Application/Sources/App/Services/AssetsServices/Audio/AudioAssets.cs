using UnityEngine;

namespace Sources.App.Services.AssetsServices.Audio
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(AudioAssets), fileName = nameof(AudioAssets))]
    public class AudioAssets : ScriptableObject
    {
        [field: SerializeField] public AudioSourceView AudioSourceViewPrefab { get; private set; }
        [field: SerializeField] public MusicData[] MusicData { get; private set; }
        [field: SerializeField] public SoundEffectData[] SoundEffectData { get; private set; }
    }
}