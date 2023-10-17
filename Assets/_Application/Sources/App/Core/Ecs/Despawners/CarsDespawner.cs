using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Common;
using Sources.Services.PoolServices;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.App.Core.Ecs.Despawners
{
    public class CarsDespawner : Despawner, ICarsDespawner
    {
        public void DespawnCar(Entity carEntity)
        {
            SwitchableRigidbodyAspect switchableRigidbodyAspect = carEntity.GetAspect<SwitchableRigidbodyAspect>();

            if (switchableRigidbodyAspect.HasPhysicBody())
                switchableRigidbodyAspect.DisableRigidbody();
            
            carEntity.GetRef<MonoEntity>().Cleanup();
            
            _poolDespawner.Despawn(carEntity.GetRef<RespawnableBehaviour>());
            
            carEntity.Dispose();
        }
    }
}