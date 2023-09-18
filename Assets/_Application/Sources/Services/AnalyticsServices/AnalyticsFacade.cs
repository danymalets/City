using System.Collections.Generic;
using Sources.Services.AnalyticsServices.Adapters;

namespace Sources.Services.AnalyticsServices
{
    internal class AnalyticsFacade
    {
        private readonly IAnalyticsAdapter[] _analyticsAdapters = 
        {
            new GameAnalyticsAdapter(),
            new FirebaseAnalyticsAdapter(),
        };

        public void Initialize()
        {
            foreach (IAnalyticsAdapter analyticsProvider in _analyticsAdapters)
            {
                analyticsProvider.Initialize();
            }
        }

        public void SendEvent(string name, Dictionary<string, string> parameters)
        {
            foreach (IAnalyticsAdapter analyticsProvider in _analyticsAdapters)
            {
                analyticsProvider.SendEvent(name, parameters);
            }
        }
    }
}