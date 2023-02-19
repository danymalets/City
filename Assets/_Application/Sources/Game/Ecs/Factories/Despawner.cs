using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Collections;
using Scellecs.Morpeh.Providers;
using Sources.Game.Ecs.Aspects;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Views.Transform;
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
            npcEntity.GetAspect<NpcStatusAspect>().LeaveIfOnPath();
            
            if (npcEntity.TryGet(out PlayerInCar playerInCar))
            {
                playerInCar.Car.Get<CarPassengers>().FreeUpPlace(playerInCar.Place, npcEntity);
            }

            npcEntity.DespawnMono();
            npcEntity.Dispose();
        }
    }
}