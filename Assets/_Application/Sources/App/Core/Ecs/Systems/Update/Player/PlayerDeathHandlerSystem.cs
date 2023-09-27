using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.Common;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Constants;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerDeathHandlerSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, DeadRequest>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                playerEntity.Add<Dead>();
                playerEntity.GetAspect<NpcStatusAspect>().LeaveIfOnPath();
                playerEntity.Get<PlayerTargetSpeed>().Value = 0;
                playerEntity.Get<PlayerSmoothSpeed>().Value = 0;
                playerEntity.Add<FallAnimationRequest>();

                playerEntity.SetWithFixedDelay(0.4f, new SetLayerRequest { Layer = Layers.Falling });
            }
        }
    }
}