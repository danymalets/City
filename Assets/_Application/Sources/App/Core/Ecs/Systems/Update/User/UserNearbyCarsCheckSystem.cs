using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.CarsBalances;
using Sources.Utils.CommonUtils.Utils;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class UserNearbyCarsCheckSystem : CustomUpdateSystem
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
            _filter = _world.Filter<UserTag>().Build();
            _carsFilter = _world.Filter<CarTag>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ITransform playerTransform = playerEntity.GetRef<ITransform>();
                
                Entity enterCar = default;
                float curMinSqrDistance = 0;

                if (!playerEntity.Has<PlayerInCar>())
                {
                    foreach (Entity carEntity in _carsFilter)
                    {
                        if (carEntity.GetAspect<CarPassengersAspect>().IsNoPassengers)
                        {
                            IEnterPoint[] carEnterPoints = carEntity.GetRef<IEnterPoint[]>();

                            IEnterPoint enterPoint = carEnterPoints[0];

                            float sqrDistance = Vector3Utils.SqrDistance(enterPoint.Position, playerTransform.Position);
                            if (sqrDistance <= MathUtils.Sqr(_carsBalance.MaxEnterCarDistance) &&
                                (enterCar == default || sqrDistance < curMinSqrDistance))
                            {
                                enterCar = carEntity;
                                curMinSqrDistance = sqrDistance;
                            }
                        }
                    }
                }

                if (enterCar != default)
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