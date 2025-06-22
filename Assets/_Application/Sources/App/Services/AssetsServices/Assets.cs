using Sources.App.Services.AssetsServices.Audio;
using Sources.App.Services.AssetsServices.Common;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.AssetsServices
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(Assets), fileName = nameof(Assets))]
    public class Assets : ScriptableObject, IService
    {
        [field: SerializeField] public LocalizationAssets LocalizationAssets { get; private set; }
        [field: SerializeField] public AudioAssets AudioAssets { get; private set; }
        [field: SerializeField] public ScenesAssets ScenesAssets { get; private set; }
        [field: SerializeField] public CommonAssets CommonAssets { get; private set; }
    }
}