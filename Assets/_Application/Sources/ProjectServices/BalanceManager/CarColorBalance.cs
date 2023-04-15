using System;
using Sources.Data;
using Sources.Data.Cars;
using UnityEngine;

namespace Sources.Services.BalanceManager
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