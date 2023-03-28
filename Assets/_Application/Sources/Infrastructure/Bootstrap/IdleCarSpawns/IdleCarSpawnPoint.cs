using Scellecs.Morpeh;
using Sirenix.OdinInspector;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.MonoEntities;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;

#if UNITY_EDITOR
using Sources.PseudoEditor; 
#endif

namespace Sources.Infrastructure.Bootstrap.IdleCarSpawns
{
    public class IdleCarSpawnPoint : MonoBehaviour
    {
        [ReadOnly]
        [SerializeField]
        private bool _visualizationEnabled;

        [ReadOnly]
        [SerializeField]
        private CarMonoEntity _visual;
#if UNITY_EDITOR
        [OnValueChanged(nameof(TryUpdatePrefab))]
#endif
        [SerializeField]
        private CarType _carType;

#if UNITY_EDITOR
        [OnValueChanged(nameof(TryUpdateColor))]
#endif
        [ShowIf(nameof(ShowCarColorField))]
        [SerializeField]
        private CarColorType _carColor;

        private bool ShowCarColorField => _carType.IsColorable();

        public CarType CarType => _carType;

        public CarColorType? CarColor => _carType.IsColorable() ? _carColor : null;

        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;

        public Entity AliveCar { get; set; } = null; 
        
        private void Awake()
        {
            if (_visual != null)
            {
                Destroy(_visual.gameObject);
                // Debug.LogWarning("Idle Car Spawn Points Visual Enabled");
            }
        }
        
#if UNITY_EDITOR
        private void TryUpdatePrefab()
        {
            if (_visual != null)
                DestroyImmediate(_visual.gameObject);

            if (!_visualizationEnabled)
                return;

            _visual = DEditor.InstantiatePrefab(DEditor.EditorServices.Assets
                .CarsAssets.GetCarPrefab(_carType), transform);

            _visual.transform.localPosition -= _visual.RootOffset;

            foreach (Collider collider in _visual.GetComponentsInChildren<Collider>())
            {
                collider.enabled = false;
            }

            foreach (IMeshRenderer meshRenderer in _visual.MeshRenderers)
            {
                meshRenderer.SharedMaterial = new Material(meshRenderer.SharedMaterial);
            }

            TryUpdateColor();
        }

        private void TryUpdateColor()
        {
            if (_visual == null)
                return;

            foreach (IMeshRenderer meshRenderer in _visual.MeshRenderers)
            {
                meshRenderer.SharedMaterial.SetInt("_TargetIndex", (int)_carColor);
            }
        }

        public void SetVisualization(bool enabled)
        {
            _visualizationEnabled = enabled;

            TryUpdatePrefab();
        }

#endif
    }
}