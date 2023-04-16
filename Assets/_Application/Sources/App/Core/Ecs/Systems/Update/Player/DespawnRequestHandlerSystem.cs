using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Despawners;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class DespawnRequestHandlerSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IPlayersDespawner _playersDespawner;

        public DespawnRequestHandlerSystem()
        {
            _playersDespawner = DiContainer.Resolve<IPlayersDespawner>();
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, DespawnRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                _playersDespawner.DespawnNpc(playerEntity);
            }
        }
    }
}