using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Npc.NpcCar;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views.CarEngine;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using UnityEngine;
using UnityEngine.Assertions;

namespace Sources.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcCarPathLineChangeSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, PlayerInCar, NpcOnPath, NpcCarPointReachedEvent>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref NpcOnPath npcOnPath = ref npcEntity.Get<NpcOnPath>();
                ref ListOf<TurnData> carTurns = ref npcEntity.Get<ListOf<TurnData>>();
                Point reachedPoint = npcEntity.Get<NpcCarPointReachedEvent>().Point;
                Entity carEntity = npcEntity.Get<PlayerInCar>().Car;
                ref QueueOf<ChoiceData> choices = ref npcEntity.Get<QueueOf<ChoiceData>>();

                ChoiceData choiceData = choices.Dequeue();
                
                Assert.AreEqual(choiceData.Point, reachedPoint);
                
                npcOnPath.PathLine = choiceData.TurnData.FirstPathLine;

                TurnData[] banTurnsToRemove = carTurns.Where(ct => ct.TargetPoint == reachedPoint).ToArray();

                
                foreach (TurnData turnData in banTurnsToRemove)
                {
                    foreach (TurnData banTurn in turnData.BlockableTurns)
                    {
                        banTurn.DecreaseBlocked();
                    }
                    carTurns.Remove(turnData);
                }
                
                if (choiceData.TurnData.TargetPoint != null)
                {
                    foreach (TurnData blockTurn in choiceData.TurnData.BlockableTurns)
                    {
                        //blockTurn.IncreaseBlocked();
                    }
                    carTurns.Add(choiceData.TurnData);
                }
            }
        }
    }
    
}