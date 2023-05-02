using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerCarExitSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, PlayerInCar, PlayerExitCarEvent>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ITransform playerTransform = playerEntity.GetAccess<ITransform>();
                ref PlayerTargetAngle playerTargetAngle = ref playerEntity.Get<PlayerTargetAngle>();
                ref PlayerSmoothAngle playerSmoothAngle = ref playerEntity.Get<PlayerSmoothAngle>();
                PlayerInCar playerInCar = playerEntity.Get<PlayerInCar>();
                CarPlaceData carPlaceData = playerInCar.CarPlaceData;
                CarPassengersAspect carPassengers = carPlaceData.Car.GetAspect<CarPassengersAspect>();
                IEnterPoint enterPoint = carPlaceData.Car.GetAccess<IEnterPoint[]>()[0];

                carPassengers.FreeUpPlace(carPlaceData.Place, playerEntity);
                playerEntity.Remove<PlayerInCar>();
            }
        }
    }
}