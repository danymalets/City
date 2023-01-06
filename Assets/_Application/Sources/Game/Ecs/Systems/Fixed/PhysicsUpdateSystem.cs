using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Systems.Fixed
{
    public class PhysicsUpdateSystem : DFixedUpdateSystem
    {
        private readonly IPhysicsService _physics;

        public PhysicsUpdateSystem()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
        }

        protected override void OnInitFilters()
        {
        }

        protected override void OnFixedUpdate(float fixedDeltaTime)
        {
            _physics.Simulate(fixedDeltaTime);
        }
    }
}