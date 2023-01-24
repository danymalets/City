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
    public class NpcPathLineChangeSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath, NpcPointReachedEvent>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref NpcOnPath npcOnPath = ref npcEntity.Get<NpcOnPath>();
                ref ListOf<TurnData> carTurns = ref npcEntity.Get<ListOf<TurnData>>();
                Point reachedPoint = npcEntity.Get<NpcPointReachedEvent>().Point;
                ref QueueOf<ChoiceData> choices = ref npcEntity.Get<QueueOf<ChoiceData>>();

                ChoiceData choiceData = choices.Dequeue();

                Assert.AreEqual(choiceData.Point, reachedPoint);

                npcOnPath.PathLine = choiceData.TurnData.FirstPathLine;

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

                if (choiceData.TurnData.TargetPoint != null)
                {
                    carTurns.Add(choiceData.TurnData);
                }
            }
        }
    }
}