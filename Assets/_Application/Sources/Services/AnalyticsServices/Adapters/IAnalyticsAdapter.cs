using System.Collections.Generic;

namespace Sources.Services.AnalyticsServices
{
    internal interface IAnalyticsAdapter
    {
        void Initialize();
        void SendEvent(string name, Dictionary<string, string> parameters);
    }
}