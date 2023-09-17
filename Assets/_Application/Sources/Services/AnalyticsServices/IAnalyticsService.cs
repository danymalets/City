namespace Sources.Services.AnalyticsServices
{
    public interface IAnalyticsService
    {
        void SendLevelCompleted(int level, float time);
        void SendCarBought(string carName, int price);
    }
}