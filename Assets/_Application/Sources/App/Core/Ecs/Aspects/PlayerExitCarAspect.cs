using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
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

namespace Sources.App.Core.Ecs.Aspects
{
    public struct PlayerExitCarAspect : IDAspect
    {
        public Entity Entity { get; set; }

        public Filter GetFilter(Filter filter) =>
            filter.With<PlayerTag>();

        public readonly void TryForceExit()
        {
            if (Entity.Has<PlayerFullyInCar>())
            {
                StartExitCar(true);
            }

            if (Entity.Has<PlayerInCar>())
            {
                FullyExitCar();
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

        public readonly void FullyExitCar(Vector3 position, float angle)
        {
            Entity.Get<PlayerSmoothAngle>().Value = angle;
            Entity.Get<PlayerTargetAngle>().Value = angle;
                
            Entity.GetRef<ITransform>().Position = position;
            Entity.GetRef<ITransform>().Rotation = Quaternion.identity.WithEulerY(angle);

            FullyExitCar();
        }

        private readonly void FullyExitCar()
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