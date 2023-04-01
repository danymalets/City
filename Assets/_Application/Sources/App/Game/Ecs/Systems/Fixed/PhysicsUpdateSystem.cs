using Sources.Di;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Services.Physics;

namespace Sources.App.Game.Ecs.Systems.Fixed
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