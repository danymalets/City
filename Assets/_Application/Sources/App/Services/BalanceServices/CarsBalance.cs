using System.Collections.Generic;
using Sources.App.Data.Cars;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.App.Services.BalanceServices
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(CarsBalance), fileName = nameof(CarsBalance))]
    public class CarsBalance : ScriptableObject
    {
        [SerializeField]
        private List<CarBalance> _carBalance = new();
        
        [field: SerializeField] public float MaxEnterCarDistance { get; private set; } = 1f;
        [field: SerializeField] public float MaxSpeed { get; private set; } = 5;
        [field: SerializeField] public float MaxMotorTorque { get; private set; } = 350;
        [field: SerializeField] public float MaxSteeringAngle { get; private set; } = 40;
        [field: SerializeField] public float Mass { get; private set; } = 400;
        [field: SerializeField] public float EnableIdleCarRigidBodyDistance { get; private set; } = 10;
        [field: SerializeField] public float DisableIdleCarRigidBodyDistance { get; private set; } = 15;

        private void OnValidate()
        {
            DValidate.ValidateEnumsData(_carBalance,
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