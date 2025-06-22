using System.Collections.Generic;

namespace Sources.Services.AnalyticsServices.Adapters
{
    internal interface IAnalyticsAdapter
    {
        void Initialize();
        void SendEvent(string name, Dictionary<string, string> parameters);
    }
}