using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Data.MonoViews;
using UnityEngine;

namespace Sources.Monos.Bootstrap.IdleCarSpawns
{
    public class IdleCarsSystem : MonoBehaviour, IIdleCarsSystem
    {
        [ReadOnly]
        [SerializeField]
        private IdleCarSpawnPoint[] _spawnPoints;

#if UNITY_EDITOR
        [OnValueChanged(nameof(ChangeVisualization))]
#endif
        [SerializeField]
        private bool _visualize;

        public IEnumerable<IIdleCarSpawnPoint> SpawnPoints => _spawnPoints;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            _spawnPoints = GetComponentsInChildren<IdleCarSpawnPoint>();
        }

        private void ChangeVisualization()
        {
            foreach (IdleCarSpawnPoint spawnPoint in _spawnPoints)
            {
                spawnPoint.SetVisualization(_visualize);
            }
        }
#endif
    }
}