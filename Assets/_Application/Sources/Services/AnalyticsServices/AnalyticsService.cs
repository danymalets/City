using System.Collections.Generic;
using System.Linq;
using Sources.Services.ApplicationServices;
using Sources.Services.TimeServices;
using Sources.Utils.Di;

namespace Sources.Services.AnalyticsServices
{
    public class AnalyticsService : IAnalyticsService, IInitializable
    {
        private readonly AnalyticsFacade _analyticsFacade;
        private readonly IApplicationService _applicationService;
        private readonly ITimeService _timeService;

        public AnalyticsService()
        {
            _analyticsFacade = new AnalyticsFacade();
            _applicationService = DiContainer.Resolve<IApplicationService>();
            _timeService = DiContainer.Resolve<ITimeService>();
        }

        public void Initialize()
        {
            _analyticsFacade.Initialize();
        }

        public void SendLevelStarted(int level)
        {
            SendEvent("level_started", new Dictionary<string, string>
            {
                ["level"] = level.ToString(),
            });
        }

        public void SendLevelFinished(int level, float time)
        {
            SendEvent("level_completed", new Dictionary<string, string>
            {
                ["level"] = level.ToString(),
                ["time"] = time.ToString("F")
            });
        }

        public void SendBoxBought(string carName, int price)
        {
            SendEvent("car_bought", new Dictionary<string, string>
            {
                ["car_name"] = carName,
                ["price"] = price.ToString()
            });
        }

        private void SendEvent(string name, Dictionary<string, string> parameters)
        {
            _analyticsFacade.SendEvent(name, parameters.Concat(new Dictionary<string, string>
            {
                ["is_internet_reachable"] = _applicationService.IsInternetReachable.ToString(),
                ["time_since_startup"] = _timeService.Time.ToString("F"),
            }).ToDictionary(x => x.Key, x => x.Value));
        }
    }
}