using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Services.AssetsServices.Monos.AssetsData;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.AssetsServices
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(Assets), fileName = nameof(Assets))]
    public class Assets : ScriptableObject, IService
    {
        [field: SerializeField] public string PlayerRenderSceneName { get; private set; } = "PlayerRender";
        [field: SerializeField] public string CitySceneName { get; private set; } = "City";
        [field: SerializeField] public CarsAssets CarsAssets { get; private set; }
        [field: SerializeField] public PlayersAssets PlayersAssets { get; private set; }
        [field: SerializeField] public LocalizationAssets LocalizationAssets { get; private set; }
        [field: SerializeField] public PhysicsAssets PhysicsAssets { get; private set; }
    }
}