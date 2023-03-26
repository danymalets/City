using System;
using Sources.Game.Ecs.MonoEntities;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [Serializable]
    public class CarData
    {
        [SerializeField]
        private CarType _carType;

        [SerializeField]
        private CarMonoEntity _carPrefab;

        public CarData(CarType carType)
        {
            _carType = carType;
        }

        public CarType CarType => _carType;
        public CarMonoEntity CarPrefab => _carPrefab;
    }
}