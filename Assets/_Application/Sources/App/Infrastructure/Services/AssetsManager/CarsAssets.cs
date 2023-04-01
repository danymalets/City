using System.Collections.Generic;
using System.Linq;
using Sources.App.Game.Ecs.MonoEntities;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.App.Infrastructure.Services.AssetsManager
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