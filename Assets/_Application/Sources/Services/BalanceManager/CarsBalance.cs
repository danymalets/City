using System.Collections.Generic;
using Sources.AssetsManager;
using Sources.Utils.Extensions;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.Services.BalanceManager
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(CarsBalance), fileName = nameof(CarsBalance))]
    public class CarsBalance : ScriptableObject
    {
        [SerializeField]
        private List<CarBalance> _carBalance = new();

        [SerializeField]
        private float _maxEnterCarDistance = 2f;

        public float MaxEnterCarDistance => _maxEnterCarDistance;

        [field: SerializeField] public float MaxSpeed { get; set; } = 5;
        [field: SerializeField] public float MaxMotorTorque { get; set; } = 350;
        [field: SerializeField] public float MaxSteeringAngle { get; set; } = 40;
        [field: SerializeField] public float Mass { get; set; } = 400;

        private void OnValidate()
        {
            DValidate.OptimizeEnumsData(_carBalance,
                cb => cb.CarType, carType => new CarBalance(carType));

            foreach (CarBalance carBalance in _carBalance)
            {
                carBalance.OnValidate();
            }
        }

        public CarColorData GetRandomCar()
        {
            CarBalance carBalance = _carBalance.GetRandomWithWeights(pb => pb.Weight);
            CarType carType = carBalance.CarType;

            if (!carType.IsColorable())
                return new CarColorData(carType, null);

            return new CarColorData(carType, carBalance.GetRandomColor());
        }
    }
}