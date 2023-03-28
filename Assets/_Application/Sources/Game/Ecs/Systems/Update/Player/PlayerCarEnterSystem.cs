using Scellecs.Morpeh;
using Sources.Game.Components.Old.CarEnterPointsData;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.DefaultComponents;
using Sources.Game.Ecs.DefaultComponents.Monos;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;

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