using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Common;
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
            
            carEntity.DespawnMono();
            _poolDespawner.Despawn(carEntity.GetMonoEntity());
            carEntity.Dispose();
        }
    }
}