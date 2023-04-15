using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Data.Pathes;
using Sources.Data.Points;
using UnityEngine;

namespace Sources.Monos.Bootstrap.IdleCarSpawns
{
    public class IdleCarsSystem : MonoBehaviour, IIdleCarsSystem
    {
        [ReadOnly]
        [SerializeField]
        private IdleCarSpawnPoint[] _spawnPoints;

        private void OnValidate()
        {
            _spawnPoints = GetComponentsInChildren<IdleCarSpawnPoint>();
        }

        public IEnumerable<IIdleCarSpawnPoint> SpawnPoints => _spawnPoints;
    }
}