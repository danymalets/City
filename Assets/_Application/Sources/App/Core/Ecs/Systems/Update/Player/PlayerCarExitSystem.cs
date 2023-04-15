using System.Linq;
using _Application.Sources.App.Core.Ecs.Components.Car;
using _Application.Sources.App.Core.Ecs.Components.Npc;
using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerCarExitSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PlayerTag, PlayerInCar, PlayerWantsExitCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ITransform playerTransform = playerEntity.GetAccess<ITransform>();
                ref PlayerTargetAngle playerTargetAngle = ref playerEntity.Get<PlayerTargetAngle>();
                ref PlayerSmoothAngle playerSmoothAngle = ref playerEntity.Get<PlayerSmoothAngle>();
                IEnableableGameObject enableableEntity = playerEntity.GetAccess<IEnableableGameObject>();
                PlayerInCar playerInCar = playerEntity.Get<PlayerInCar>();
                Entity carEntity = playerInCar.Car;
                int place = playerInCar.Place;
                CarPassengers carPassengers = carEntity.Get<CarPassengers>();
                IEnterPoint enterPoint = carEntity.GetAccess<ICarEnterPoints>().EnterPoints.First();

                carPassengers.FreeUpPlace(place, playerEntity);
                playerEntity.Remove<PlayerInCar>();

                playerTransform.Position = enterPoint.Position + Vector3.up * 0.0f;

                float angle = enterPoint.Rotation.eulerAngles.y;
                playerTransform.Rotation = Quaternion.Euler(0, angle, 0);
                playerTargetAngle.Value = angle;
                playerSmoothAngle.Value = angle;

                enableableEntity.Enable();
            }
        }
    }
}