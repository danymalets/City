using System.Collections.Generic;

namespace Sources.Services.AnalyticsServices
{
    internal interface IAnalyticsProvider
    {
        void SendEvent(string name, Dictionary<string, string> parameters);
    }
}