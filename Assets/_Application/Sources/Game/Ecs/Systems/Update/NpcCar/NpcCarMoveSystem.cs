using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Infrastructure.Services;
using Sources.Utilities.Extensions;

namespace Sources.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcCarMoveSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IPhysicsService _physics;

        public NpcCarMoveSystem()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag, PlayerInCar, NpcOnPath>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                Entity carEntity = npcEntity.Get<PlayerInCar>().Car;
                ref CarMotorCoefficient carMotorCoefficient = ref carEntity.Get<CarMotorCoefficient>();
                ref CarBreak carBreak = ref carEntity.Get<CarBreak>();
                ref ForwardTrigger forwardTrigger = ref carEntity.Get<ForwardTrigger>();

                Entity[] entities = _physics.OverlapBox(forwardTrigger.Center, forwardTrigger.Size / 2, 
                        forwardTrigger.Rotation, LayerMasks.CarsAndPlayers)
                    .Select(c => c.transform.root.gameObject)
                    .Where(r => r.HasComponent<MonoEntity>())
                    .Select(r => r.GetComponent<MonoEntity>().Entity)
                    .Where(e => e != carEntity)
                    .ToArray();
                
                if (entities.Any())
                {
                    carMotorCoefficient.Coefficient = 0;
                    carBreak.BreakType = BreakType.Max;
                }
                else
                {
                    carMotorCoefficient.Coefficient = 1;
                    carBreak.BreakType = BreakType.None;
                }
            }
        }
    }
}