using _Application.Sources.Utils.Di;
using UnityEngine;

namespace Sources.ProjectServices.AssetsServices
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(Assets), fileName = nameof(Assets))]
    public class Assets : ScriptableObject, IService
    {
        [SerializeField]
        private string _citySceneNameName;

        [SerializeField]
        private CarsAssets _carsAssets;

        [SerializeField]
        private PlayersAssets _playersAssets;

        public string CitySceneName => _citySceneNameName;

        public CarsAssets CarsAssets => _carsAssets;

        public PlayersAssets PlayersAssets => _playersAssets;

        [field: SerializeField] public PhysicsAssets PhysicsAssets { get; private set; }
    }
}