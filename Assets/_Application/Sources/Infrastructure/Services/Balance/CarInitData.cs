using System;
using Sources.Game.Ecs.MonoEntities;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [Serializable]
    public class CarInitData
    {
        [SerializeField]
        private CarMonoEntity _carPrefab;

        [SerializeField]
        private float _weight = 100;

        public CarMonoEntity CarPrefab => _carPrefab;
        public float Weight => _weight;
    }
}