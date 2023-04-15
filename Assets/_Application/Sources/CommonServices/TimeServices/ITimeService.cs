using _Application.Sources.Utils.Di;

namespace _Application.Sources.CommonServices.TimeServices
{
    public interface ITimeService : IService
    {
        float Time { get; }
        float DeltaTime { get; }
        float FixedDeltaTime { get; }
        int PhysicsUpdateCount { get; set; }
        float TimeScale { set; get; }
    }
}