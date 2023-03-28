using Scellecs.Morpeh;
using Sources.Game.Ecs.Aspects;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Utils.MorpehUtils;
using UnityEngine;

namespace Sources.Game.Ecs.Despawners
{
    public class PlayersDespawner : Despawner, IPlayersDespawner
    {

        public void DespawnNpc(Entity playerEntity)
        {
            playerEntity.GetAspect<NpcStatusAspect>().LeaveIfOnPath();
            
            if (playerEntity.TryGet(out PlayerInCar playerInCar))
            {
                playerInCar.Car.Get<CarPassengers>().FreeUpPlace(playerInCar.Place, playerEntity);
            }

            SwitchableRigidbodyAspect switchableRigidbodyAspect = playerEntity.GetAspect<SwitchableRigidbodyAspect>();
            
            if (switchableRigidbodyAspect.HasPhysicBody())
                switchableRigidbodyAspect.DisablePhysicBody();
            
            playerEntity.DespawnMono();
            playerEntity.Dispose();
        }
    }
}