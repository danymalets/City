using Leopotam.Ecs;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Times;

namespace Sources.Game.Ecs.Systems.Fixed
{
    public class PhysicsUpdateSystem : IEcsRunSystem
    {
        private readonly IPhysicsService _physics;
        private readonly ITimeService _time;

        public PhysicsUpdateSystem()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
            _time = DiContainer.Resolve<ITimeService>();
        }

        public void Run()
        {
            _physics.Simulate(_time.FixedDeltaTime);
        }
    }
}