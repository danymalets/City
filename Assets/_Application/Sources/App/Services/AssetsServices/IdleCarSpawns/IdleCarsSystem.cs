using System.Collections.Generic;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using TriInspector;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.IdleCarSpawns
{
    public class IdleCarsSystem : MonoBehaviour, IIdleCarsSystem
    {
        [ReadOnly]
        [SerializeField]
        private CarSpawnPoint[] _spawnPoints;

        private void OnValidate()
        {
            _spawnPoints = GetComponentsInChildren<CarSpawnPoint>();
        }

        public IEnumerable<ICarSpawnPoint> SpawnPoints => _spawnPoints;
    }
}