using System;
using Sources.Utils.Di;

namespace Sources.Services.AdsServices
{
    public interface IAdsService : IService
    {
        bool IsRewardedAvailable { get; }
        void ShowRewarded(Action onSuccess, Action onFailed);
    }
}