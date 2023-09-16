using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class UserNearbyCarsCheckSystem : DUpdateSystem
    {
        private Filter _filter;
        private Filter _carsFilter;
        private readonly CarsBalance _carsBalance;

        public UserNearbyCarsCheckSystem()
        {
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<UserTag>().Without<PlayerInCar>();
            _carsFilter = _world.Filter<CarTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ITransform playerTransform = playerEntity.GetRef<ITransform>();
                
                Entity enterCar = null;
                float curMinSqrDistance = 0;

                foreach (Entity carEntity in _carsFilter)
                {
                    if (carEntity.GetAspect<CarPassengersAspect>().IsNoPassengers)
                    {
                        IEnterPoint[] carEnterPoints = carEntity.GetRef<IEnterPoint[]>();

                        IEnterPoint enterPoint = carEnterPoints[0];

                        float sqrDistance = DVector3.SqrDistance(enterPoint.Position, playerTransform.Position);
                        if (sqrDistance <= DMath.Sqr(_carsBalance.MaxEnterCarDistance) &&
                            (enterCar == null || sqrDistance < curMinSqrDistance))
                        {
                            enterCar = carEntity;
                            curMinSqrDistance = sqrDistance;
                        }
                    }
                }

                if (enterCar != null)
                {
                    playerEntity.Set(new CarInputPossibility { CarEntity = enterCar });
                }
                else
                {
                    playerEntity.RemoveIfHas<CarInputPossibility>();
                }
            }
        }
    }
}