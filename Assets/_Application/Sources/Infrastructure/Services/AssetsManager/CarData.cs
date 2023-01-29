using System;
using Sources.Game.Ecs.MonoEntities;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [Serializable]
    public class CarData
    {
        public CarType CarType;
        
        [SerializeField]
        private CarMonoEntity _carPrefab;
        
        public CarMonoEntity CarPrefab => _carPrefab;
    }
}