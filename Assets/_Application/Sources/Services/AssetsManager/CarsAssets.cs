using System.Collections.Generic;
using System.Linq;
using Sources.Data;
using Sources.Monos.MonoEntities;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.Services.AssetsManager
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(CarsAssets), fileName = nameof(CarsAssets))]
    public class CarsAssets : ScriptableObject
    {
        [SerializeField]
        private List<CarAsset> _carData = new();

        public IEnumerable<CarMonoEntity> CarPrefabs => 
            _carData.Select(d => d.CarPrefab);

        private void OnValidate()
        {
            DValidate.OptimizeEnumsData(_carData, 
                cd => cd.CarType, 
                cd => new CarAsset(cd));
        }
        
        public CarMonoEntity GetCarPrefab(CarType carType) =>
            _carData.First(cd => cd.CarType == carType).CarPrefab;
    }
}