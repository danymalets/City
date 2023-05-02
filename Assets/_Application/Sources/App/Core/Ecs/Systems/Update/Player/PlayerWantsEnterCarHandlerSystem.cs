using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerWantsEnterCarHandlerSystem : DUpdateSystem
    {
        private Filter _filter;
        private Filter _carsFilter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, PlayerWantsEnterCarEvent>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                CarPlaceData carPlaceData = playerEntity.Get<PlayerWantsEnterCarEvent>().CarPlaceData;
                playerEntity.Set(new PlayerEnterCarEvent { CarPlaceData = carPlaceData });
            }
        }
    }
}