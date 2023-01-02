using Sources.Game.Characters;
using Sources.Game.GameObjects.Cars;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Services.AssetsManager
{
    public class AssetsService : MonoBehaviour, IAssetsService
    {
        [SerializeField]
        private Car _carPrefab;

        [SerializeField]
        private Npc _npcPrefab;

        [SerializeField]
        private Player _playerPrefab;

        [SerializeField]
        private Scene _emptyScene;
        
        [SerializeField]
        private Scene _cityScene;
        
        public Car CarPrefab => _carPrefab;
        public Npc NpcPrefab => _npcPrefab;
        public Player PlayerPrefab => _playerPrefab;
        public Scene EmptyScene => _emptyScene;
        public Scene CityScene => _cityScene;
    }
}