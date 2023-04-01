using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Aspects;
using Sources.DMorpeh.MorpehUtils.Extensions;

namespace Sources.App.Game.Ecs.Despawners
{
    public class CarsDespawner : Despawner, ICarsDespawner
    {
        public void DespawnCar(Entity carEntity)
        {
            SwitchableRigidbodyAspect switchableRigidbodyAspect = carEntity.GetAspect<SwitchableRigidbodyAspect>();

            if (switchableRigidbodyAspect.HasPhysicBody())
                switchableRigidbodyAspect.DisablePhysicBody();
            
            carEntity.DespawnMono();
            carEntity.Dispose();
        }
    }
}