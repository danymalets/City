using Scellecs.Morpeh;
using Sources.Game.Ecs.Aspects;
using Sources.Game.Ecs.Utils.MorpehWrapper;

namespace Sources.Game.Ecs.Despawners
{
    public class CarsDespawner : Despawner, ICarsDespawner
    {
        public CarsDespawner(World world) : base(world)
        {
        }
        
        public void DespawnCar(Entity carEntity)
        {
            SwitchableRigidbodyAspect switchableRigidbodyAspect = carEntity.GetAspect<SwitchableRigidbodyAspect>();

            // if (switchableRigidbodyAspect.HasPhysicBody())
            //     switchableRigidbodyAspect.DisablePhysicBody();
            
            carEntity.DespawnMono();
            carEntity.Dispose();
        }
    }
}