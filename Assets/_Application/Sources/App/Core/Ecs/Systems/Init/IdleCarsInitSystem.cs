using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Core.Services;
using Sources.App.Data.Common;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.CommonServices.PhysicsServices;
using Sources.ProjectServices.AssetsServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
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