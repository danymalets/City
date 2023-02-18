using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class DespawnRequestHandlerSystem : DUpdateSystem
    {
        private Filter _filter;

        public DespawnRequestHandlerSystem()
        {
            _despawner = DiContainer.Resolve<IDespawner>();
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, DespawnRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                _despawner.DespawnNpc(playerEntity);
            }
        }
    }
}