using System.Collections.Generic;
using System.Linq;
using Sources.Data.MonoEntities;
using Sources.Monos.Bootstrap.IdleCarSpawns;
using Sources.Monos.MonoEntities;
using Sources.Services.MonoServices;
using Sources.Services.Pool;
using UnityEngine;

namespace Sources.Editor
{
    [ExecuteInEditMode]
    public class CarSpawnPointsSystem : MonoBehaviour
    {
        [SerializeField]
        private List<CarIdleData> CarIdleData = new();

        private void Update()
        {
            Debug.Log($"deb update");

            Dictionary<IdleCarSpawnPoint, CarIdleData> existedVisuals =
                CarIdleData.ToDictionary(d => d.IdleCarSpawnPoint, d => d);
            
            return;

            foreach (IdleCarSpawnPoint spawnPoint in FindObjectsOfType<IdleCarSpawnPoint>())
            {
                if (existedVisuals.ContainsKey(spawnPoint))
                {
                    existedVisuals.Remove(spawnPoint);
                }
                else
                {
                    CarIdleData.Add(new CarIdleData(spawnPoint, CreateVisual(spawnPoint)));
                }
            }

            foreach ((IdleCarSpawnPoint spawnPoint, CarIdleData carIdleData) in existedVisuals)
            {
                EditorInstantiator.Destroy(carIdleData.CarMonoEntity);
            }
        }

        private ICarMonoEntity CreateVisual(IdleCarSpawnPoint spawnPoint)
        {
            ICarMonoEntity carPrefab = ProjectAssets.EditorServices.Assets.CarsAssets
                .GetCarPrefab(spawnPoint.CarType);

            ICarMonoEntity carMonoEntity = EditorInstantiator.Instantiate(
                carPrefab, Vector3.zero, Quaternion.identity, transform);
            
            return carMonoEntity;
        }
    }
}