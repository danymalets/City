using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Npc.NpcCar;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities.Extensions;

namespace Sources.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcPathChoiceSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcPathChoiceSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref QueueOf<ChoiceData> choices = ref npcEntity.Get<QueueOf<ChoiceData>>();
                NpcOnPath npcOnPath = npcEntity.Get<NpcOnPath>();
                
                while (choices.Count < _simulationBalance.PreSolvePathChoiceCount)
                {
                    Point lastPoint = choices.Count == 0 ? npcOnPath.PathLine.Target : 
                        choices.Last().TurnData.FirstPathLine.Target;
                    
                    choices.Enqueue(new ChoiceData(lastPoint, lastPoint.Targets.GetRandom()));
                }
            }
        }
    }
}