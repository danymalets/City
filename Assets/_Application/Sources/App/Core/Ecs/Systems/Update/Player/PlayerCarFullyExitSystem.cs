using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Data.Constants;
using Sources.App.Data.Players;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerCarFullyExitSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, PlayerInCar, PlayerFullyExitCarRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ITransform playerTransform = playerEntity.GetRef<ITransform>();
                SwitchableRigidbodyAspect switchableRigidbodyAspect = playerEntity.GetAspect<SwitchableRigidbodyAspect>();
                ref PlayerTargetAngle playerTargetAngle = ref playerEntity.Get<PlayerTargetAngle>();
                ref PlayerSmoothAngle playerSmoothAngle = ref playerEntity.Get<PlayerSmoothAngle>();
                PlayerInCar playerInCar = playerEntity.Get<PlayerInCar>();
                CarPlaceData carPlaceData = playerInCar.CarPlaceData;
                CarPassengersAspect carPassengers = carPlaceData.Car.GetAspect<CarPassengersAspect>();
                ICollider[] colliders = playerEntity.GetRef<ICollider[]>();

                IEnterPoint enterPoint = carPlaceData.Car.GetRef<IEnterPoint[]>()[carPlaceData.Place];

                Vector3 position = enterPoint.Position;
                
                float angle = Vector3.SignedAngle(Vector3.left,
                    Vector3.Cross(enterPoint.Rotation.GetForward(), Vector3.up), Vector3.up);
                
                playerTargetAngle.Value = angle;
                playerSmoothAngle.Value = angle;
                
                playerTransform.Position = position;
                playerTransform.Rotation = Quaternion.identity.WithEulerY(angle);
                
                playerEntity.GetAspect<PlayerExitCarAspect>().FullyExitCar(position, angle);
            }
        }
    }
}