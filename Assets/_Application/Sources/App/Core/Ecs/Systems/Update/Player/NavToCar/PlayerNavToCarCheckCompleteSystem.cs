using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.NavPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player.NavToCar
{
    public class PlayerNavToCarCheckCompleteSystem : DUpdateSystem
    {
        private Filter _playerFilter;
        private readonly PlayersBalance _playersBalance;
        
        public PlayerNavToCarCheckCompleteSystem()
        {
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
        }

        protected override void OnInitFilters()
        {
            _playerFilter = _world.Filter<PlayerTag, OnNavToCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            float sqrDistance = DMath.Sqr(_playersBalance.DistanceToEnterCar);

            foreach (Entity playerEntity in _playerFilter)
            {
                CarPlaceData carPlaceData = playerEntity.Get<OnNavToCar>().PlaceData;

                IEnterPoint enterPoint = carPlaceData.Car.GetAspect<CarEnterPointsAspect>()
                    .GetEnterPoint(carPlaceData.Place);

                playerEntity.Remove<OnNavToCar>();
                
                if (DVector3.SqrDistance(playerEntity.GetRef<ITransform>().Position,
                        enterPoint.Position) <= sqrDistance)
                {
                    playerEntity.Set(new NavToCarCompletedEvent
                    {
                        PlaceData = carPlaceData
                    });
                }
            }
        }
    }
}