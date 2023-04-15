using _Application.Sources.App.Core.Ecs.Aspects;
using _Application.Sources.App.Core.Ecs.Components.Car;
using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Despawners
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