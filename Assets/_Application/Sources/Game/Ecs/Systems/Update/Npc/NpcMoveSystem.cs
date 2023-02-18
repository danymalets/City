using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views.CarForwardTriggers;
using Sources.Game.Ecs.Components.Views.PlayerDatas;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Utilities.Extensions;

namespace Sources.Game.Ecs.Systems.Update.Npc
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
                        forwardTrigger.Rotation, LayerMasks.CarsAndPlayers)
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