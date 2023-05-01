using System;
using Sources.App.Data.Cars;
using Sources.ProjectServices.AssetsServices.Monos.MonoEntities;
using UnityEngine;

namespace Sources.ProjectServices.AssetsServices
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