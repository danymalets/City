using System.Linq;
using Scellecs.Morpeh;
using Sources.App.DMorpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Constants;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Infrastructure.Services;
using Sources.App.Infrastructure.Services.Physics;
using Sources.Utils.Extensions;

namespace Sources.App.Game.Ecs.Systems.Update.Npc
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
                    .Select(r => r.GetComponent<MonoEntity>().Entity)
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