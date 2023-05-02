using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerInCarPositionUpdaterSystem : DUpdateSystem
    {
        private Filter _filter;
        private Filter _carsFilter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ITransform transform = playerEntity.GetAccess<ITransform>();
                CarPlaceData carPlaceData = playerEntity.Get<PlayerInCar>().CarPlaceData;

                IEnterPoint enterPoint = carPlaceData.Car
                    .GetAccess<IEnterPoint[]>()[carPlaceData.Place];
                
                transform.Position = enterPoint.Position;
                transform.Rotation = enterPoint.Rotation;
            }
        }
    }
}