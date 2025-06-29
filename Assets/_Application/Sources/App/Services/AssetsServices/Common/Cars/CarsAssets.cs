using System.Collections.Generic;
using System.Linq;
using Sources.App.Services.AssetsServices.Common.Cars.CarsData;
using Sources.App.Services.AssetsServices.Common.MonoEntities.Car;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Cars
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(CarsAssets), fileName = nameof(CarsAssets))]
    public class CarsAssets : ScriptableObject
    {
        [SerializeField]
        private List<CarAsset> _carData = new();
        
        public IEnumerable<CarMonoEntity> CarPrefabs => 
            _carData.Select(d => d.CarPrefab);
        
        public CarMonoEntity GetCarPrefab(CarType carType) =>
            _carData.First(cd => cd.CarType == carType).CarPrefab;
    }
}