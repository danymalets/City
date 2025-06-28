using System;
using System.Collections.Generic;
using Sources.App.Services.AssetsServices.Common.Monos.Cars;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Utils;
using TriInspector;
using UnityEngine;

namespace Sources.App.Services.BalanceServices.CarsBalances
{
    [Serializable]
    public class CarBalance
    {
        [SerializeField]
        private CarType _carType;

        [SerializeField]
        private float _weight = 100;

        // ReSharper disable once UnusedMember.Local
        private bool Hide => !_carType.IsColorable();
        
        [HideIf(nameof(Hide))]
        [SerializeField]
        private List<CarColorBalance> _carColorBalance = new();
        
        public CarType CarType => _carType;
        public float Weight => _weight;

        public CarBalance(CarType carType)
        {
            _carType = carType;
        }

        public void OnValidate()
        {
            if (!_carType.IsColorable())
            {
                _carColorBalance.Clear();
            }
        }

        public CarColorType GetRandomColor() => 
            _carColorBalance.GetRandomWithWeights(pb => pb.Weight).CarColorColorType;
    }
    
}