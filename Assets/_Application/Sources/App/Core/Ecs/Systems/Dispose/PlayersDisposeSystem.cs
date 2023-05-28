using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Despawners;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Dispose
{
    public class PlayersDisposeSystem : DDisposer
    {
        private Filter _filter;
        private readonly IPlayersDespawner _playersDespawner;

        public PlayersDisposeSystem()
        {
            _playersDespawner = DiContainer.Resolve<IPlayersDespawner>();
        }
        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag>();
        }

        protected override void OnDispose()
        {
            foreach (Entity playerEntity in _filter)
            {
                _playersDespawner.DespawnPlayer(playerEntity);
            }
        }
    }
}