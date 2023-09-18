using Sources.Utils.Di;

namespace Sources.Services.AnalyticsServices
{
    public interface IAnalyticsService : IService
    {
        void SendLevelStarted(int level);
        void SendLevelCompleted(int level, float time);
        void SendCarBought(string carName, int price);
    }
}