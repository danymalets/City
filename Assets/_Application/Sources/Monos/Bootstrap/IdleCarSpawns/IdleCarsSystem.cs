using System.Collections.Generic;
using _Application.Sources.App.Data.Pathes;
using _Application.Sources.App.Data.Points;
using Sirenix.OdinInspector;
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