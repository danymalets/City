using System.Collections.Generic;
using System.Linq;

namespace Sources.Services.AnalyticsServices.Adapters
{
    public class FirebaseAnalyticsAdapter : IAnalyticsAdapter
    {
        public void Initialize()
        {
            
        }

        public void SendEvent(string name, Dictionary<string, string> parameters)
        {
            Firebase.Analytics.FirebaseAnalytics.LogEvent(
                Firebase.Analytics.FirebaseAnalytics.EventLevelUp,
                parameters.Select(p => new Firebase.Analytics.Parameter(
                    p.Key, p.Value)).ToArray());
        }
    }
}