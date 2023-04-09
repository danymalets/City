using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Npc.NpcCar;
using Sources.App.Game.Ecs.Components.NpcPathes;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Data;
using Sources.Data.Cars;
using Sources.Data.Points;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;

namespace Sources.App.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcPathLineChangeSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath, NpcPointReachedEvent>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref NpcOnPath npcOnPath = ref npcEntity.Get<NpcOnPath>();
                List<TurnData> carTurns = npcEntity.Get<ActiveTurns>().List;
                Point reachedPoint = npcEntity.Get<NpcPointReachedEvent>().Point;
                Queue<TurnChoice> choices = npcEntity.Get<TurnDecisions>().Queue;

                TurnChoice turnChoice = choices.Dequeue();

                if (turnChoice.Point == reachedPoint)
                {
                    npcOnPath.PathLine = turnChoice.TurnData.FirstPathLine;

                    TurnData[] banTurnsToRemove = carTurns.Where(ct => ct.TargetPoint == reachedPoint).ToArray();

                    foreach (TurnData turnData in banTurnsToRemove)
                    {
                    
                        foreach (TurnData banTurn in turnData.BlockableTurns)
                        {
                            // Debug.Log($"decrease block");
                            banTurn.DecreaseBlocked();
                        }

                        carTurns.Remove(turnData);
                    }
                }
            }
        }
    }
}