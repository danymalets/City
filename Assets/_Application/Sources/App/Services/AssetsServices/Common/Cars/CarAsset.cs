using System;
using Sources.App.Services.AssetsServices.Common.Cars.CarsData;
using Sources.App.Services.AssetsServices.Common.MonoEntities.Car;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Cars
{
    [Serializable]
    public class CarAsset
    {
        [SerializeField]
        private CarType _carType;

        [SerializeField]
        private CarMonoEntity _carPrefab;

        public CarAsset(CarType carType)
        {
            _carType = carType;
        }

        public CarType CarType => _carType;
        public CarMonoEntity CarPrefab => _carPrefab;
    }
}