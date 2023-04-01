using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Aspects;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;

namespace Sources.App.Game.Ecs.Systems.Update.Player
{
    public class PlayerDeathHandlerSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PlayerTag, DeadRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                playerEntity.Add<Dead>();
                playerEntity.GetAspect<NpcStatusAspect>().LeaveIfOnPath();
                playerEntity.Add<FallAnimationRequest>();
                playerEntity.AddWithDelay<DisableCollidersRequest>(0.5f);
                playerEntity.AddWithDelay<MakeKinematicRequest>(0.5f);
                //playerEntity.AddWithDelay<DespawnRequest>(2.5f);
            }
        }
    }
}