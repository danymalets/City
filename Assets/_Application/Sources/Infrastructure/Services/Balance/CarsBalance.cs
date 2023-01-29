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
        private List<CarBalance> _carBalance;

        private void OnValidate()
        {
            DValidate.AddRequired(_carBalance,
                cb => cb.CarType,
                (cd, en) => cd.CarType = en);
        }

        public CarType GetRandomCarType() =>
            _carBalance.GetRandomWithWeights(pb => pb.Weight).CarType;
    }
}