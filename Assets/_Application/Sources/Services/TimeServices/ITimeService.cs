using Sources.Utils.Di;

namespace Sources.Services.TimeServices
{
    public interface ITimeService : IService
    {
        float Time { get; }
        double RealtimeSinceStartup { get; }
        float DeltaTime { get; }
        float FixedDeltaTime { get; }
        int PhysicsUpdateCount { get; set; }
        float TimeScale { set; get; }
    }
}