using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.App.Infrastructure.Bootstrap.IdleCarSpawns
{
    public class IdleCarsSystem : MonoBehaviour
    {
        [ReadOnly]
        [SerializeField]
        private IdleCarSpawnPoint[] _spawnPoints;

#if UNITY_EDITOR
        [OnValueChanged(nameof(ChangeVisualization))]
#endif
        [SerializeField]
        private bool _visualize;

        public IdleCarSpawnPoint[] SpawnPoints => _spawnPoints;

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