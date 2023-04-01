using System;
using Sources.App.Game.Ecs.MonoEntities;
using UnityEngine;

namespace Sources.AssetsManager
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