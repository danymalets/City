using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.NavPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player.NavToCar
{
    public class PlayerNavigationCompletedHandlerSystem : DUpdateSystem
    {
        private Filter _playerFilter;
        
        protected override void OnInitFilters()
        {
            _playerFilter = _world.Filter<PlayerTag, NavPathCompletedEvent>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _playerFilter)
            {
                playerEntity.Remove<PLayerOnNavPath>();
            }
        }
    }
}