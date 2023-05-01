using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player
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
                playerEntity.GetAspect<NpcStatusAspect>().LeaveIfOnPath();
                playerEntity.Add<FallAnimationRequest>();
                playerEntity.AddWithDelay<SetFallenLayerRequest>(0.5f);
                // playerEntity.AddWithDelay<MakeKinematicRequest>(0.5f);
                //playerEntity.AddWithDelay<DespawnRequest>(2.5f);
            }
        }
    }
}