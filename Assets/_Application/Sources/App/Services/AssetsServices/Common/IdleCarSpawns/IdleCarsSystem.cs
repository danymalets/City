using System.Collections.Generic;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;
using TriInspector;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.IdleCarSpawns
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