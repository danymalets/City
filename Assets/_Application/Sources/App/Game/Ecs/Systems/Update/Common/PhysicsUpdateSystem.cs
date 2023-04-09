using Sources.Services.Di;
using Sources.Services.Physics;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;

namespace Sources.App.Game.Ecs.Systems.Update.Common
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