using Sources.App.Services.AssetsServices.Common.Cars;
using Sources.App.Services.AssetsServices.Common.Players;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(CommonAssets), fileName = nameof(CommonAssets))]
    public class CommonAssets : ScriptableObject
    {
        [field: SerializeField] public CarsAssets CarsAssets { get; private set; }
        [field: SerializeField] public PlayersAssets PlayersAssets { get; private set; }
        [field: SerializeField] public PhysicsAssets PhysicsAssets { get; private set; }
    }
}