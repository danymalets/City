using System.Linq;
using _Application.Sources.App.Core.Ecs.Components.Car;
using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Constants;
using _Application.Sources.CommonServices.PhysicsServices;
using _Application.Sources.Utils.CommonUtils.Extensions;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Npc
{
    public class NpcMoveSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IPhysicsService _physics;

        public NpcMoveSystem()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
        }

        protected override void OnConstruct()
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