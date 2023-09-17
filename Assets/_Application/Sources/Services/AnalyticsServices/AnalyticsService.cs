using System.Collections.Generic;

namespace Sources.Services.AnalyticsServices
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly AnalyticsWrapper _eventSender;

        public AnalyticsService()
        {
            _eventSender = new AnalyticsWrapper();
        }

        public void SendLevelCompleted(int level, float time)
        {
            _eventSender.SendEvent("level_completed", new Dictionary<string, string>()
            {
                ["level"] = level.ToString(),
                ["time"] = time.ToString()
            });
        }

        public void SendCarBought(string carName, int price)
        {
            _eventSender.SendEvent("car_bought", new Dictionary<string, string>()
            {
                ["car_name"] = carName,
                ["price"] = price.ToString()
            });
        }
    }
}