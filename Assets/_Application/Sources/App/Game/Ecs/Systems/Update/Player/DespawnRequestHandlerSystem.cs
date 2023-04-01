using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Despawners;
using Sources.App.Infrastructure.Services;

namespace Sources.App.Game.Ecs.Systems.Update.Player
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