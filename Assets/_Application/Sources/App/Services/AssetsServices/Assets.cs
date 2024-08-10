using Sources.App.Services.AssetsServices.Localizations;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.AssetsServices
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(Assets), fileName = nameof(Assets))]
    public class Assets : ScriptableObject, IService
    {
        [field: SerializeField] public string CitySceneName { get; private set; } = "City";
        [field: SerializeField] public LocalizationAssets LocalizationAssets { get; private set; }
    }
}