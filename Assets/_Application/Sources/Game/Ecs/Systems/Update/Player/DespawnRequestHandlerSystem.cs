using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Despawners;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class DespawnRequestHandlerSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IPlayersDespawner _playersDespawner;

        public DespawnRequestHandlerSystem()
        {
            _playersDespawner = DiContainer.Resolve<IPlayersDespawner>();
        }

        protected override void OnConstruct()
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