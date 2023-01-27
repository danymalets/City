using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Components.Views.CarEnterPointsData;
using Sources.Game.Ecs.Components.Views.EnableDisable;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class PlayerCarEnterSystem : DUpdateSystem
    {
        private Filter _filter;
        private Filter _carsFilter;

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
                
                foreach (Entity carEntity in _carsFilter)
                {
                    ICarEnterPoints carEnterPoints = carEntity.GetMono<ICarEnterPoints>();

                    foreach (IEnterPoint enterPoint in carEnterPoints.EnterPoints)
                    {
                        if (DVector3.SqrDistance(enterPoint.Position, playerTransform.Position) <= 2 * 2)
                        {
                            enterCar = carEntity;
                        }
                    }
                }

                if (enterCar != null)
                {
                    enableDisableEntity.Disable();
                    playerEntity.Set(new PlayerInCar { Car = enterCar });
                }
            }
        }
    }
}