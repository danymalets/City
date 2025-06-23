using UnityEngine;

namespace Sources.App.Services.AssetsServices.Localizations
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(StringsAsset), fileName = nameof(StringsAsset))]
    public class StringsAsset : ScriptableObject
    {
        [field: SerializeField] public string Play { get; private set; }
        [field: SerializeField] public string Settings { get; private set; }
        [field: SerializeField] public string Shop { get; private set; }
        [field: SerializeField] public string RateUs { get; private set; }
        [field: SerializeField] public string CoinsPattern { get; private set; }
        [field: SerializeField] public string RedBox { get; private set; }
        [field: SerializeField] public string GreenBox { get; private set; }
        [field: SerializeField] public string RemoveAds { get; private set; }
        [field: SerializeField] public string RestorePurchases { get; private set; }
        [field: SerializeField] public string Bought { get; private set; }
        [field: SerializeField] public string Language { get; private set; }
        [field: SerializeField] public string Sounds { get; private set; }
        [field: SerializeField] public string Music { get; private set; }
        [field: SerializeField] public string Vibration { get; private set; }
        [field: SerializeField] public string Support { get; private set; } 
        [field: SerializeField] public string Pause { get; private set; }
        [field: SerializeField] public string Continue { get; private set; }
        [field: SerializeField] public string Restart { get; private set; }
        [field: SerializeField] public string Leave { get; private set; }
        [field: SerializeField] public string LoadingPattern { get; private set; }
        [field: SerializeField] public string Special { get; private set; }
    }
}