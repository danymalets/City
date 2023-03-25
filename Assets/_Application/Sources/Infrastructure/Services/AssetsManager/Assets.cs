using Sources.Game.Ecs.MonoEntities;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Services.AssetsManager
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