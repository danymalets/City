using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.Game.Ecs.Aspects;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Player;

namespace Sources.App.Game.Ecs.Despawners
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