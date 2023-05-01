#if UNITY_EDITOR

using Sirenix.OdinInspector;
using Sources.App.Data.Cars;
using Sources.App.Data.Constants;
using Sources.App.Data.MonoEntities;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.Services.PoolServices;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.IdleCarSpawns
{
    [ExecuteInEditMode]
    public class CarSpawnPointEditor : MonoBehaviour
    {
        [ReadOnly]
        [SerializeField]
        private CarMonoEntity _visualModel;

        [ReadOnly]
        [SerializeField]
        private CarSpawnPoint _spawnPoint;
        
        [ReadOnly]
        [SerializeField]
        private CarType _carType;
        
        [ReadOnly]
        [SerializeField]
        private CarColorType _carColor; 
        
        private void Awake()
        {
            if (Application.isPlaying)
                return;
            
            _spawnPoint = GetComponent<CarSpawnPoint>();
            InstantiateNew();
            UpdateColor();
        }

        private void InstantiateNew()
        {
            TryForceDestroy();

            Debug.Log($"inst new");
            _carType = _spawnPoint.CarType;
            _carColor = _spawnPoint.CarColor;

            ICarMonoEntity carMonoEntity = EditorAssets.Assets.CarsAssets.GetCarPrefab(_spawnPoint.CarType);
            _visualModel = EditorInstantiator.InstantiateAsPrefab<ICarMonoEntity, CarMonoEntity>(carMonoEntity, transform);
            _visualModel.transform.localPosition -= _visualModel.WheelsSystem.RootOffset;
            _visualModel.gameObject.hideFlags = HideFlags.HideAndDontSave;
        }

        private void TryForceDestroy()
        {
            if (_visualModel != null)
                GameObject.DestroyImmediate(_visualModel.gameObject);
        }

        private void Update()
        {
            if (Application.isPlaying)
                return;
            
            if (_visualModel == null || _carType != _spawnPoint.CarType)
            {
                InstantiateNew();
                UpdateColor();
            }

            if (_carColor != _spawnPoint.CarColor)
            {
                UpdateColor();
            }
        }

        private void UpdateColor()
        {
            _carColor = _spawnPoint.CarColor;
            MaterialPropertyBlock materialPropertyBlock = new();
            materialPropertyBlock.SetInt(ShaderProperties.CarTargetIndex, (int)_carColor);
            foreach (IMeshRenderer meshRenderer in _visualModel.MeshRenderers)    
            {
                meshRenderer.SetPropertyBlock(materialPropertyBlock);
            }
        }

        [Button("Force Update", ButtonSizes.Large)]
        private void ForceUpdate()
        {
            InstantiateNew();
            UpdateColor();
        }
    }
}

#endif