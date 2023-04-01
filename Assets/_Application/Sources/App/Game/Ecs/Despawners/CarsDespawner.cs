using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.Game.Ecs.Aspects;

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