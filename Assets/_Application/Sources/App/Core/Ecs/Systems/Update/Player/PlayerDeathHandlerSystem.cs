using _Application.Sources.App.Core.Ecs.Aspects;
using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Player
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