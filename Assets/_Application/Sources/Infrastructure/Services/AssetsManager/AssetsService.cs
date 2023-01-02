using Sources.Game.Characters;
using Sources.Game.GameObjects.Cars;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Services.AssetsManager
{
    public class AssetsService : MonoBehaviour, IAssetsService
    {
        [SerializeField]
        private GameObject _carPrefab;

        [SerializeField]
        private GameObject _npcPrefab;

        [SerializeField]
        private GameObject _playerPrefab;

        [SerializeField]
        private Scene _emptyScene;
        
        [FormerlySerializedAs("_citySceneName")]
        [SerializeField]
        private string _cityScene;
        
        public GameObject CarPrefab => _carPrefab;
        public GameObject NpcPrefab => _npcPrefab;
        public GameObject PlayerPrefab => _playerPrefab;
        public Scene EmptyScene => _emptyScene;
        public string CityScene => _cityScene;
    }
}