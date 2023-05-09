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
    public struct PlayerEnterCarAspect : IDAspect
    {
        public Entity Entity { get; set; }

        public Filter GetFilter(Filter filter) =>
            filter.With<PlayerTag>();

        public readonly void ForceEnterCar(CarPlaceData carPlaceData) =>
            StartEnterCar(carPlaceData, true);
        
        public readonly void StartEnterCar(CarPlaceData carPlaceData) =>
            StartEnterCar(carPlaceData, false);

        private readonly void StartEnterCar(CarPlaceData carPlaceData, bool isForceEndEnter)
        {
            Entity.Set(new PlayerInCar { CarPlaceData = carPlaceData});

            IEnterPoint placeEnterPoint = carPlaceData.Car.GetRef<IEnterPoint[]>()[carPlaceData.Place];
            
            Entity.GetAspect<SwitchableRigidbodyAspect>().DisableRigidbody();
            
            if (isForceEndEnter)
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
            Entity.GetRef<IPlayerAnimator>().EnterCar(placeEnterPoint.SideType, isForceEndEnter);

            Entity.Remove<PlayerSmoothSpeed>();
            Entity.Remove<PlayerTargetSpeed>();

            foreach (ICollider collider in Entity.GetRef<ICollider[]>())
            {
                collider.Enabled = false;
            }

            carPlaceData.Car.GetAspect<CarPassengersAspect>()
                .TakePlaceInternal(carPlaceData.Place, Entity);
        }
    }
}