using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Constants;
using Sources.CommonServices.PhysicsServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Npc
{
    public class NpcMoveSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IPhysicsService _physics;

        public NpcMoveSystem()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                float speed = 1;
                ForwardTrigger forwardTrigger = npcEntity.Get<ForwardTrigger>();
                ref PlayerTargetSpeed playerTargetSpeed = ref npcEntity.Get<PlayerTargetSpeed>();
                
                Entity[] entities = _physics.OverlapBox(forwardTrigger.Center, forwardTrigger.Size / 2, 
                        forwardTrigger.Rotation, LayerMasks.CarsBordersAndPlayers)
                    .Select(c => c.transform.root.gameObject)
                    .Where(r => r.HasComponent<MonoEntity>())
                    .Select(r => r.GetComponent<IEntityAccess>().Entity)
                    .Where(e => e != npcEntity)
                    .ToArray();

                if (entities.Any())
                {
                    playerTargetSpeed.Value = 0;
                }
                else
                {
                    playerTargetSpeed.Value = speed;
                }
            }
        }
    }
}