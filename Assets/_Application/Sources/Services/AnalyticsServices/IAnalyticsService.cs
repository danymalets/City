using Sources.Utils.Di;

namespace Sources.Services.AnalyticsServices
{
    public interface IAnalyticsService : IService
    {
        void SendLevelStarted(int level);
        void SendLevelFinished(int level, float time);
        void SendBoxBought(string carName, int price);
    }
}