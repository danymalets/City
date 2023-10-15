using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects.Car;
using Sources.App.Core.Ecs.Aspects.Common;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Data.Constants;
using Sources.App.Data.Players;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;

namespace Sources.App.Core.Ecs.Aspects.Player
{
    public struct PlayerExitCarAspect : IDAspect
    {
        public Entity Entity { get; set; }

        public FilterBuilder GetFilter(FilterBuilder filter) =>
            filter.With<PlayerTag>();

        public readonly void TryForceExit()
        {
            if (Entity.Has<PlayerFullyInCar>())
            {
                StartExitCar(true);
            }

            if (Entity.Has<PlayerInCar>())
            {
                FullyExitCarInternal();
            }
        }

        public readonly void StartExitCar() =>
            StartExitCar(false);
        
        private readonly void StartExitCar(bool isForce)
        {
            CarPlaceData carPlaceData = Entity.Get<PlayerInCar>().CarPlaceData;
           
            if (carPlaceData.Place == 0)
                carPlaceData.Car.Set(new CarBreak { BreakType = BreakType.Max });
            
            Entity.Remove<PlayerFullyInCar>();
            Entity.Remove<PlayerInputInCarOn>();

            if (!isForce)
            {
                Entity.AddWithFixedDelay<PlayerFullyExitCarRequest>(Consts.ExitCarAnimationDuration);
            }
           
            Entity.GetRef<IPlayerAnimator>().ExitCar();
        }

        public readonly void FullyExitCar()
        {
            CarPlaceData carPlaceData = Entity.Get<PlayerInCar>().CarPlaceData;

            IEnterPoint enterPoint = carPlaceData.Car.GetRef<IEnterPoint[]>()[carPlaceData.Place];
            
            float angle = Vector3.SignedAngle(Vector3.left,
                Vector3.Cross(enterPoint.Rotation.GetForward(), Vector3.up), Vector3.up);
            
            Entity.Get<PlayerSmoothAngle>().Value = angle;
            Entity.Get<PlayerTargetAngle>().Value = angle;
                
            Entity.GetRef<ITransform>().Position = enterPoint.Position;
            Entity.GetRef<ITransform>().Rotation = Quaternion.identity.WithEulerY(angle);

            FullyExitCarInternal();
        }

        private readonly void FullyExitCarInternal()
        {
            CarPlaceData carPlaceData = Entity.Get<PlayerInCar>().CarPlaceData;
            
            Entity.Remove<PlayerInCar>();
            
            Entity.Set(new PlayerSmoothSpeed { Value = 0 });
            Entity.Set(new PlayerTargetSpeed { Value = 0 });

            foreach (ICollider collider in Entity.GetRef<ICollider[]>())
            {
                collider.Enabled = true;
            }

            Entity.GetAspect<SwitchableRigidbodyAspect>().EnableRigidbody();
            
            carPlaceData.Car.GetAspect<CarPassengersAspect>()
                .FreeUpPlaceInternal(carPlaceData.Place, Entity);
        }
    }
}