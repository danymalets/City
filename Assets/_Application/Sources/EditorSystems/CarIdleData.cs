using System;
using _Application.Sources.App.Data.MonoEntities;
using Sources.Monos.Bootstrap.IdleCarSpawns;
using UnityEngine;

namespace _Application.Sources.EditorSystems
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