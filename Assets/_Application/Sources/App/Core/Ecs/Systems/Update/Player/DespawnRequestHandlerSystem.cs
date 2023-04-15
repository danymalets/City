using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Core.Ecs.Despawners;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Player
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