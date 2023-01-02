using UnityEngine;

namespace Sources.Infrastructure.Bootstrap
{
    public class LevelContext : SceneContext, ILevelContext
    {
        [SerializeField]
        public SpawnPoint _userSpawnPoint;

        public ISpawnPoint UserSpawnPoint => _userSpawnPoint;
    }
}