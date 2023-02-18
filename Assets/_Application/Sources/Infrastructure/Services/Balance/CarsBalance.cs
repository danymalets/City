using System.Collections.Generic;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(CarsBalance), fileName = nameof(CarsBalance))]
    public class CarsBalance : ScriptableObject
    {
        [SerializeField]
        private List<CarBalance> _carBalance = new();

        [SerializeField]
        private float _maxEnterCarDistance = 2f;

        public float MaxEnterCarDistance => _maxEnterCarDistance;

        private void OnValidate()
        {
            DValidate.OptimizeEnumsData(_carBalance, 
                cb => cb.CarType, carType => new CarBalance(carType));

            foreach (CarBalance carBalance in _carBalance)
            {
                carBalance.OnValidate();
            }
        }

        public (CarType carType, CarColorType carColorType) GetRandomCar()
        {
            CarBalance carBalance = _carBalance.GetRandomWithWeights(pb => pb.Weight);
            CarType carType = carBalance.CarType;

            if (!carType.IsColorable())
                return (carType, CarColorType.None);

            return (carType, carBalance.GetRandomColor());
        }
    }
}