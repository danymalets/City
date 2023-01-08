using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sources.Game.Ecs.MonoEntities;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(CarsAssets), fileName = nameof(CarsAssets))]
    public class CarsAssets : ScriptableObject
    {
        [SerializeField]
        private CarInitData[] _carInitData;

        public IEnumerable<CarMonoEntity> CarPrefabs => 
            _carInitData.Select(d => d.CarPrefab);

        public CarMonoEntity GetRandomCar() =>
            _carInitData.GetRandomWithWights(d => (d.CarPrefab, d.Weight));
    }
}