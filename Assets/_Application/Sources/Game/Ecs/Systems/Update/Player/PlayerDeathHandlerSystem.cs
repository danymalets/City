using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class PlayerDeathHandlerSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, DeadRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                playerEntity.Add<Dead>();
                playerEntity.Add<FallAnimationRequest>();
                playerEntity.AddWithDelay<DisableCollidersRequest>(0.8f);
                playerEntity.AddWithDelay<MakeKinematicRequest>(0.8f);
                //playerEntity.AddWithDelay<DespawnRequest>(2.5f);
            }
        }
    }
}