using System.Collections.Generic;
using Sources.Utils.Di;

namespace Sources.Services.AnalyticsServices
{
    public class AnalyticsService : IAnalyticsService, IInitializable
    {
        private readonly AnalyticsFacade _analyticsFacade;

        public AnalyticsService()
        {
            _analyticsFacade = new AnalyticsFacade();
        }

        public void Initialize()
        {
            _analyticsFacade.Initialize();
        }

        public void SendLevelStarted(int level)
        {
            _analyticsFacade.SendEvent("level_started", new Dictionary<string, string>
            {
                ["level"] = level.ToString(),
            });
        }

        public void SendLevelCompleted(int level, float time)
        {
            _analyticsFacade.SendEvent("level_completed", new Dictionary<string, string>
            {
                ["level"] = level.ToString(),
                ["time"] = time.ToString()
            });
        }

        public void SendCarBought(string carName, int price)
        {
            _analyticsFacade.SendEvent("car_bought", new Dictionary<string, string>
            {
                ["car_name"] = carName,
                ["price"] = price.ToString()
            });
        }
    }
}