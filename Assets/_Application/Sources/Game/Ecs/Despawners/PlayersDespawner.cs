using Scellecs.Morpeh;
using Sources.Game.Ecs.Aspects;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Despawners
{
    public class PlayersDespawner : Despawner, IPlayersDespawner
    {
        public PlayersDespawner(World world) : base(world)
        {
        }

        public void DespawnNpc(Entity playerEntity)
        {
            playerEntity.GetAspect<NpcStatusAspect>().LeaveIfOnPath();
            
            if (playerEntity.TryGet(out PlayerInCar playerInCar))
            {
                playerInCar.Car.Get<CarPassengers>().FreeUpPlace(playerInCar.Place, playerEntity);
            }

            // SwitchableRigidbodyAspect switchableRigidbodyAspect = playerEntity.GetAspect<SwitchableRigidbodyAspect>();
            //
            // if (switchableRigidbodyAspect.HasPhysicBody())
            //     switchableRigidbodyAspect.DisablePhysicBody();
            Debug.Log($"despawn player");
            
            playerEntity.DespawnMono();
            playerEntity.Dispose();
        }
    }
}