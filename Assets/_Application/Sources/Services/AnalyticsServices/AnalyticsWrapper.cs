using System.Collections.Generic;

namespace Sources.Services.AnalyticsServices
{
    internal class AnalyticsWrapper
    {
        private readonly IAnalyticsProvider[] _analyticsProviders = new IAnalyticsProvider[]
        {
            
        };
        
        public void SendEvent(string name, Dictionary<string, string> parameters)
        {
            foreach (IAnalyticsProvider analyticsProvider in _analyticsProviders)
            {
                analyticsProvider.SendEvent(name, parameters);
            }
            
            
        }
    }
}