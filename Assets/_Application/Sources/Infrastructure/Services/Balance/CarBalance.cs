using System;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [Serializable]
    public class CarBalance
    {
        public CarType CarType;

        [SerializeField]
        private float _weight = 100;

        public float Weight => _weight;
    }
}