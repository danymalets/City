using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.App.Core.Ecs.Despawners
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
            _poolDespawner.Despawn(playerEntity.GetMonoEntity());
            playerEntity.Dispose();
        }
    }
}