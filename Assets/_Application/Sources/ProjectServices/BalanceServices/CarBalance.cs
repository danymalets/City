using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.App.Data.Cars;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.ProjectServices.BalanceServices
{
    [Serializable]
    public class CarBalance
    {
        [SerializeField]
        private CarType _carType;

        [SerializeField]
        private float _weight = 100;

        private bool Show => _carType.IsColorable();
        
        [ShowIf("Show")]
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
            if (_carType.IsColorable())
            {
                DValidate.OptimizeEnumsData(_carColorBalance,
                    cct => cct.CarColorColorType,
                    cct => new CarColorBalance(cct),
                new []{CarColorType.None});
            }
            else
            {
                _carColorBalance.Clear();
            }
        }

        public CarColorType GetRandomColor() => 
            _carColorBalance.GetRandomWithWeights(pb => pb.Weight).CarColorColorType;
    }
    
}