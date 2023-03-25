using Scellecs.Morpeh;
using Sources.Game.Components.Views;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Despawners;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Generation
{
    public class InactiveCarsDespawnSystem : DUpdateSystem
    {
        private Filter _carFilter;
        private Filter _userFilter;
        private readonly SimulationBalance _simulationBalance;
        private readonly ICarsDespawner _carsDespawner;

        public InactiveCarsDespawnSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
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

                Vector2 maxSize = new(_simulationBalance.CarMaxActiveRadius, _simulationBalance.CarMaxActiveRadius);

                if (directionToEntity.y < 0)
                {
                    maxSize.y = _simulationBalance.BackCarMaxActiveRadius;
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