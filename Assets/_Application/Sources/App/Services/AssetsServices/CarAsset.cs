using System;
using Sources.App.Data.Cars;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using UnityEngine;

namespace Sources.App.Services.AssetsServices
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