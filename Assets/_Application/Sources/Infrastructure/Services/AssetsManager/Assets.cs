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
        
        [FormerlySerializedAs("_carsBalance")]
        [SerializeField]
        private CarsAssets _carsAssets;

        [FormerlySerializedAs("_playersBalance")]
        [SerializeField]
        private PlayersAssets _playersAssets;
        
        public string CitySceneName => _citySceneNameName;
        
        public CarsAssets CarsAssets => _carsAssets;

        public PlayersAssets PlayersAssets => _playersAssets;
    }
}