using Scellecs.Morpeh;
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
    public struct PlayerCarPossibilityAspect : IDAspect
    {
        public Entity Entity { get; set; }

        public Filter GetFilter(Filter filter) =>
            filter.With<PlayerTag>();

        public readonly void EnterCar(CarPlaceData carPlaceData, bool isForce = false)
        {
            Entity.Set(new PlayerInCar { CarPlaceData = carPlaceData});

            IEnterPoint placeEnterPoint = carPlaceData.Car.GetRef<IEnterPoint[]>()[carPlaceData.Place];
            
            Entity.GetAspect<SwitchableRigidbodyAspect>().DisableRigidbody();
            
            if (isForce)
            {
                if (carPlaceData.Place == 0)
                {
                    Entity.Add<PlayerInputInCarOn>();
                }
                
                Entity.Add<PlayerFullyInCar>();
            }
            else
            {
                if (carPlaceData.Place == 0)
                {
                    Entity.AddWithFixedDelay<PlayerInputInCarOn>(Consts.EnterCarInputOnDuration);
                }
                
                Entity.AddWithFixedDelay<PlayerFullyInCar>(Consts.EnterCarAnimationDuration);
            }
            
            Entity.GetRef<IPlayerAnimator>().SetMoveSpeed(0);
            Entity.GetRef<IPlayerAnimator>().EnterCar(placeEnterPoint.SideType, isForce);

            Entity.Remove<PlayerSmoothSpeed>();
            Entity.Remove<PlayerTargetSpeed>();

            foreach (ICollider collider in Entity.GetRef<ICollider[]>())
            {
                collider.Enabled = false;
            }

            carPlaceData.Car.GetAspect<CarPassengersAspect>()
                .TakePlaceInternal(carPlaceData.Place, Entity);
        }

        public readonly void ExitCar(Vector3 position, float angle)
        {
            Entity.Get<PlayerSmoothAngle>().Value = angle;
            Entity.Get<PlayerTargetAngle>().Value = angle;
                
            Entity.GetRef<ITransform>().Position = position;
            Entity.GetRef<ITransform>().Rotation = Quaternion.identity.WithEulerY(angle);

            ForceExitCar();
        }

        public readonly void TryForceExit()
        {
            if (IsInCar())
                ForceExitCar();
        }

        private readonly void ForceExitCar()
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

        public readonly bool IsInCar() =>
            Entity.Has<PlayerInCar>();
    }
}