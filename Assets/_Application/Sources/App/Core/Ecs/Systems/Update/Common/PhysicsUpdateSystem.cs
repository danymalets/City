using _Application.Sources.CommonServices.PhysicsServices;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Common
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