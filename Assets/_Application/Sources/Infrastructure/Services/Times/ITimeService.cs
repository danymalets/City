namespace Sources.Infrastructure.Services.Times
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