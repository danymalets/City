using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Components.Views.CarEnterPointsData;
using Sources.Game.Ecs.Components.Views.EnableDisable;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using Sources.Utilities.Extensions;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class PlayerCarEnterSystem : DUpdateSystem
    {
        private Filter _filter;
        private Filter _carsFilter;
        private readonly CarsBalance _carsBalance;

        public PlayerCarEnterSystem()
        {
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, PlayerWantsEnterCar>().Without<PlayerInCar>();
            _carsFilter = _world.Filter<CarTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ITransform playerTransform = playerEntity.GetMono<ITransform>();
                IEnableDisableEntity enableDisableEntity = playerEntity.GetMono<IEnableDisableEntity>();

                Entity enterCar = null;
                float curMinSqrDistance = 0;
                
                foreach (Entity carEntity in _carsFilter)
                {
                    if (carEntity.Get<CarPassengers>().IsNoPassengers)
                    {
                        ICarEnterPoints carEnterPoints = carEntity.GetMono<ICarEnterPoints>();

                        foreach (IEnterPoint enterPoint in carEnterPoints.EnterPoints)
                        {
                            float sqrDistance = DVector3.SqrDistance(enterPoint.Position, playerTransform.Position);
                            if (sqrDistance <= DMath.Sqr(_carsBalance.MaxEnterCarDistance) &&
                                (enterCar == null || sqrDistance < curMinSqrDistance))
                            {
                                enterCar = carEntity;
                                curMinSqrDistance = sqrDistance;
                            }
                        }
                    }
                }

                if (enterCar != null)
                {
                    enableDisableEntity.Disable();
                    playerEntity.Set(new PlayerInCar { Car = enterCar });
                    enterCar.Get<CarPassengers>().TakePlace(0, playerEntity);
                }
            }
        }
    }
}