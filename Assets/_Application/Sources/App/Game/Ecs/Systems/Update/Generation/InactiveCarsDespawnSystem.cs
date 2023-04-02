using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Player.User;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Despawners;
using Sources.Data.MonoViews.MonoViews;
using Sources.Services.Di;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Extensions;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.Generation
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