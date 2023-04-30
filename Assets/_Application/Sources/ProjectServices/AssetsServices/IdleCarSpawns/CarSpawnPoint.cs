using Sirenix.OdinInspector;
using Sources.App.Data.Cars;
using Sources.App.Data.Points;
using UnityEngine;

namespace Sources.ProjectServices.AssetsServices.IdleCarSpawns
{
#if UNITY_EDITOR
    [RequireComponent(typeof(CarSpawnPointEditor))]
#endif
    public class CarSpawnPoint : MonoBehaviour, ICarSpawnPoint
    {
        [SerializeField]
        private CarType _carType;
        
#if UNITY_EDITOR
        private bool ShowCarColorField => _carType.IsColorable();
        [ShowIf(nameof(ShowCarColorField))]
#endif
        [SerializeField]
        private CarColorType _carColor;
        
        public CarType CarType => _carType;
        public CarColorType CarColor => _carType.IsColorable() ? _carColor : CarColorType.None;

        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;

        private void Awake()
        {
            foreach (Transform transform in transform)
            {
                DestroyImmediate(transform.gameObject);
            }
        }

        // #if UNITY_EDITOR
//         private void TryUpdatePrefab()
//         {
//             if (_visual != null)
//                 DestroyImmediate(_visual.gameObject);
//
//             if (!_visualizationEnabled)
//                 return;
//
//             // _visual = DEditor.InstantiatePrefab(ProjectAssets.EditorServices.Assets
//             //     .CarsAssets.GetCarPrefab(_carType), transform);
//
//             _visual.transform.localPosition -= _visual.RootOffset;
//
//             foreach (Collider collider in _visual.GetComponentsInChildren<Collider>())
//             {
//                 collider.enabled = false;
//             }
//
//             foreach (IMeshRenderer meshRenderer in _visual.MeshRenderers)
//             {
//                 meshRenderer.SharedMaterial = new Material(meshRenderer.SharedMaterial);
//             }
//
//             TryUpdateColor();
//         }
//
//         private void TryUpdateColor()
//         {
//             if (_visual == null)
//                 return;
//
//             foreach (IMeshRenderer meshRenderer in _visual.MeshRenderers)
//             {
//                 meshRenderer.SharedMaterial.SetInt("_TargetIndex", (int)_carColor);
//             }
//         }
//
//         public void SetVisualization(bool enabled)
//         {
//             _visualizationEnabled = enabled;
//
//             TryUpdatePrefab();
//         }
//
// #endif
    }
}