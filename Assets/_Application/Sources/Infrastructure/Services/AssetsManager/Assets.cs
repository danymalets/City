using Sources.Game.Ecs.MonoEntities;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Services.AssetsManager
{
    public class Assets : MonoBehaviour, IService
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