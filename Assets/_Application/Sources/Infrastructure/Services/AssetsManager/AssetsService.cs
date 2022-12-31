using Sources.Game.Characters;
using Sources.Game.GameObjects.Cars;
using UnityEngine;

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
        
        public Car CarPrefab => _carPrefab;
        public Npc NpcPrefab => _npcPrefab;
        public Player PlayerPrefab => _playerPrefab;
    }
}