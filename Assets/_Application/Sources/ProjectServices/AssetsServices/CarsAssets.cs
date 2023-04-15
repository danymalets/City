using System.Collections.Generic;
using System.Linq;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.App.Data.MonoEntities;
using _Application.Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.ProjectServices.AssetsServices
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(CarsAssets), fileName = nameof(CarsAssets))]
    public class CarsAssets : ScriptableObject
    {
        [SerializeField]
        private List<CarAsset> _carData = new();

        public IEnumerable<ICarMonoEntity> CarPrefabs => 
            _carData.Select(d => d.CarPrefab);

        private void OnValidate()
        {
            DValidate.OptimizeEnumsData(_carData, 
                cd => cd.CarType, 
                cd => new CarAsset(cd));
        }
        
        public ICarMonoEntity GetCarPrefab(CarType carType) =>
            _carData.First(cd => cd.CarType == carType).CarPrefab;
    }
}