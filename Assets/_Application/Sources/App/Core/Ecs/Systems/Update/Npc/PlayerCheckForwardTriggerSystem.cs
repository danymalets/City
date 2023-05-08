using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Constants;
using Sources.Services.PhysicsServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Npc
{
    public class PlayerCheckForwardTriggerSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IPhysicsService _physics;

        public PlayerCheckForwardTriggerSystem()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, CheckForwardTriggerRequest>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                CheckForwardTriggerRequest checkForwardTriggerRequest = playerEntity.Get<CheckForwardTriggerRequest>();
                
                Entity[] entities = _physics.OverlapBox(checkForwardTriggerRequest.Center, checkForwardTriggerRequest.Size / 2, 
                        checkForwardTriggerRequest.Rotation, LayerMasks.CarBordersPlayersEnvironment)
                    .Where(r => r.HasComponent<IEntityAccess>())
                    .Select(r => r.GetComponent<IEntityAccess>().Entity)
                    .Where(e => e != playerEntity)
                    .ToArray();

                if (entities.Any())
                    playerEntity.Add<ForwardBlockerRequest>();
            }
        }
    }
}