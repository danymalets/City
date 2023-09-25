using UnityEngine;

namespace Sources.App.Services.AssetsServices.Localizations
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(LocalizationAssets), fileName = nameof(LocalizationAssets))]
    public class LocalizationAssets : ScriptableObject
    {
        [field: SerializeField] public Language DefaultLanguage { get; private set; }
        [field: SerializeField] public Language[] Languages { get; private set; }
    }
}