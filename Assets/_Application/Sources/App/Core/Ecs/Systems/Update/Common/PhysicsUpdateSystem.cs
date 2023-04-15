using Sources.CommonServices.PhysicsServices;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Common
{
    public class PhysicsUpdateSystem : DUpdateSystem
    {
        private readonly IPhysicsService _physics;

        public PhysicsUpdateSystem()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
        }

        protected override void OnConstruct()
        {
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            _physics.Simulate(fixedDeltaTime);
        }
    }
}