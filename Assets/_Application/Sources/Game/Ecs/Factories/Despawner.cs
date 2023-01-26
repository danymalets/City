using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public class Despawner : IDespawner
    {
        public void DespawnCar(Entity carEntity)
        {
            carEntity.DespawnMono();
            carEntity.Dispose();
        }
        
        public void DespawnNpc(Entity npcEntity)
        {
            List<TurnData> activeTurns = npcEntity.GetList<ActiveTurns, TurnData>();
            
            foreach (TurnData activeTurn in activeTurns)
            {
                foreach (TurnData blockedTurn in activeTurn.BlockableTurns)
                {
                    blockedTurn.DecreaseBlocked();
                }
            }
            activeTurns.Clear();
            
            npcEntity.DespawnMono();
            npcEntity.Dispose();
        }
    }
}