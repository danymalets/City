using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Despawners;
using Sources.App.Core.Services;
using Sources.App.Data.Cars;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Generation
{
    public class InactiveCarsDespawnSystem : DUpdateSystem
    {
        private Filter _carFilter;
        private Filter _userFilter;
        private readonly SimulationSettings _simulationSettings;
        private readonly ICarsDespawner _carsDespawner;

        public InactiveCarsDespawnSystem()
        {
            _simulationSettings = DiContainer.Resolve<SimulationSettings>();
            _carsDespawner = DiContainer.Resolve<ICarsDespawner>();
        }

        protected override void OnConstruct()
        {
            _userFilter = _world.Filter<UserTag>();
            _carFilter = _world.Filter<CarTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            PlayerFollowTransform userTransform = _userFilter.GetSingleton().Get<PlayerFollowTransform>();
            
            foreach (Entity carEntity in _carFilter)
            {
                ref CarPassengers carPassengers = ref carEntity.Get<CarPassengers>();
                Vector3 carPosition = carEntity.GetAccess<IWheelsSystem>().RootPosition;
                
                Vector2 directionToEntity = (Quaternion.Inverse(userTransform.Rotation) *
                                                     (carPosition - userTransform.Position)).GetXZ();

                Vector2 maxSize = new(_simulationSettings.CarMaxActiveRadius, _simulationSettings.CarMaxActiveRadius);

                if (directionToEntity.y < 0)
                {
                    maxSize.y = _simulationSettings.BackCarMaxActiveRadius;
                }
                
                if (!DMath.InEllipse(directionToEntity, maxSize) &&
                    carPassengers.IsNoPassengers)
                {
                    _carsDespawner.DespawnCar(carEntity);
                }
            }
        }
    }
}