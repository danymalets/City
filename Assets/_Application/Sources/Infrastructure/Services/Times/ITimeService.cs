namespace Sources.Infrastructure.Services.Times
{
    public interface ITimeService : IService
    {
        void StopTime();
        void ReturnTime();
        void SetTimeScale(float value);
        void ResetTimeScale();
        bool IsTimeStopped { get; }
    }
}