using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Common;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.Services.PoolServices;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.App.Core.Ecs.Despawners
{
    public class PlayersDespawner : Despawner, IPlayersDespawner
    {
        public void DespawnPlayer(Entity playerEntity)
        {
            playerEntity.GetAspect<NpcStatusAspect>().LeaveIfOnPath();

            playerEntity.GetAspect<PlayerExitCarAspect>().ForceExit();

            playerEntity.GetAspect<SwitchableRigidbodyAspect>().TryDisableRigidbody();
            
            playerEntity.GetRef<MonoEntity>().Cleanup();
            
            _poolDespawner.Despawn(playerEntity.GetRef<RespawnableBehaviour>());
            
            playerEntity.Dispose();
        }
    }
}