using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views.CarEngine;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Generation
{
    public class InactiveCarsDespawnSystem : DUpdateSystem
    {
        private Filter _carFilter;
        private Filter _userFilter;
        private readonly SimulationBalance _simulationBalance;

        public InactiveCarsDespawnSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag>();
            _carFilter = _world.Filter<CarTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            float sqrMaxRadius = DMath.Sqr(_simulationBalance.MaxCarActiveRadius);
            
            Vector3 userPosition = _userFilter.GetSingleton().Get<PlayerFollowTransform>().Position;

            foreach (Entity carEntity in _carFilter)
            {
                ref CarPassengers carPassengers = ref carEntity.Get<CarPassengers>();
                Vector3 carPosition = carEntity.GetMono<ICarWheels>().RootPosition;
                
                if (DMath.Greater(DVector3.SqrDistance(carPosition, userPosition), sqrMaxRadius) &&
                    carPassengers.IsNoPassengers)
                {
                    _despawner.DespawnCar(carEntity);
                }
            }
        }
    }
}