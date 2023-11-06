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
        [field: SerializeField] public string RedCar { get; private set; }
        [field: SerializeField] public string GreenCar { get; private set; }
        [field: SerializeField] public string RemoveAds { get; private set; }
        [field: SerializeField] public string RestorePurchases { get; private set; }
        [field: SerializeField] public string Bought { get; private set; }
        [field: SerializeField] public string Language { get; private set; }
    }
}