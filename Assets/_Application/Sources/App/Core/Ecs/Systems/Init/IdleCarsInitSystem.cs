using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Init
{
    public class IdleCarsInitSystem : DInitializer
    {
        private readonly IIdleCarsSystem _idleCarsSystem;
        private readonly ICarsFactory _carsFactory;

        public IdleCarsInitSystem()
        {
            _idleCarsSystem = DiContainer.Resolve<ILevelContext>().IdleCarsSystem;
            _carsFactory = DiContainer.Resolve<ICarsFactory>();
        }

        protected override void OnInitialize()
        {
            foreach (ICarSpawnPoint point in _idleCarsSystem.SpawnPoints)
            {
                if (!_carsFactory.TryCreateCar(point.CarType, point.CarColor, point.Position,
                        point.Rotation, true, out Entity createdCar))
                {
                    Debug.LogError("cannot create car");
                }
            }
        }
    }
}