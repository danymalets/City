using System.Collections.Generic;
using System.Linq;
using Sources.Game.Ecs.MonoEntities;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Services.AssetsManager
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(CarsAssets), fileName = nameof(CarsAssets))]
    public class CarsAssets : ScriptableObject
    {
        [SerializeField]
        private List<CarData> _carData = new();

        public IEnumerable<CarMonoEntity> CarPrefabs => 
            _carData.Select(d => d.CarPrefab);

        private void OnValidate()
        {
            DValidate.OptimizeEnumsData(_carData, 
                cd => cd.CarType, 
                cd => new CarData(cd));
        }
        
        public CarMonoEntity GetCarPrefab(CarType carType) =>
            _carData.First(cd => cd.CarType == carType).CarPrefab;
    }
}