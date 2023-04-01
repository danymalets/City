using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Components.Old.CarEnterPointsData;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Components.User;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using Sources.App.Infrastructure.Services;
using Sources.App.Infrastructure.Services.Balance;
using Sources.Utils.Libs;

namespace Sources.App.Game.Ecs.Systems.Update.Player
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

        protected override void OnConstruct()
        {
            _filter = _world.Filter<UserTag>().Without<PlayerInCar>();
            _carsFilter = _world.Filter<CarTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ITransform playerTransform = playerEntity.GetAccess<ITransform>();
                IEnableableGameObject enableableEntity = playerEntity.GetAccess<IEnableableGameObject>();

                Entity enterCar = null;
                float curMinSqrDistance = 0;
                
                foreach (Entity carEntity in _carsFilter)
                {
                    if (carEntity.Get<CarPassengers>().IsNoPassengers)
                    {
                        ICarEnterPoints carEnterPoints = carEntity.GetAccess<ICarEnterPoints>();

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
                    if (playerEntity.Has<PlayerWantsEnterCar>())
                    {
                        enableableEntity.Disable();
                        playerEntity.Set(new PlayerInCar { Car = enterCar });
                        enterCar.Get<CarPassengers>().TakePlace(0, playerEntity);
                    }
                }

                playerEntity.SetEnable<CarInputPossibility>(enterCar != null);
            }
        }
    }
}