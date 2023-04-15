using System;
using Sources.Data.MonoEntities;
using Sources.Monos.Bootstrap.IdleCarSpawns;
using Sources.Monos.MonoEntities;
using UnityEngine;

namespace Sources.Editor
{
    [Serializable]
    public class CarIdleData
    {
        [field: SerializeField] public IdleCarSpawnPoint IdleCarSpawnPoint { get; private set; }
        [field: SerializeField] public ICarMonoEntity CarMonoEntity { get; private set; }

        public CarIdleData(IdleCarSpawnPoint idleCarSpawnPoint, ICarMonoEntity carMonoEntity)
        {
            IdleCarSpawnPoint = idleCarSpawnPoint;
            CarMonoEntity = carMonoEntity;
        }
    }
}