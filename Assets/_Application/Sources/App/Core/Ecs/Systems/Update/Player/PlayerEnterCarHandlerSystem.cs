using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Data.Constants;
using Sources.App.Data.Players;
using Sources.App.Services.BalanceServices;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerEnterCarHandlerSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<UserTag, PlayerEnterCarEvent>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                SwitchableRigidbodyAspect switchableRigidbodyAspect = playerEntity.GetAspect<SwitchableRigidbodyAspect>();
                IPlayerAnimator playerAnimator = playerEntity.GetRef<IPlayerAnimator>();
                ICollider[] colliders = playerEntity.GetRef<ICollider[]>();
                CarPlaceData carPlaceData = playerEntity.Get<PlayerEnterCarEvent>().CarPlaceData;
                
                playerEntity.Set(new PlayerInCar { CarPlaceData = carPlaceData});
                carPlaceData.Car.GetAspect<CarPassengersAspect>().TakePlace(0, playerEntity);
                playerAnimator.SetInCarLeft(true);

                foreach (ICollider collider in colliders)
                {
                    collider.Enabled = false;
                }

                playerEntity.AddWithDelay<PlayerFullyInCar>(Consts.EnterCarAnimationDuration);
                
                switchableRigidbodyAspect.DisableRigidbody();
            }
        }
    }
}