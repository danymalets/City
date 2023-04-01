using System;
using Sources.App.Infrastructure.Services.AssetsManager;
using UnityEngine;

namespace Sources.App.Infrastructure.Services.Balance
{
    [Serializable]
    public class CarColorBalance
    {
        [SerializeField]
        public CarColorType _carColorType;

        [SerializeField]
        private float _weight = 100;
        
        public CarColorType CarColorColorType => _carColorType;
        public float Weight => _weight;
        
        public CarColorBalance(CarColorType carColorColorType)
        {
            _carColorType = carColorColorType;
        }
    }
}