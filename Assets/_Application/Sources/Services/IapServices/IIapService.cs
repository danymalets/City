using System;
using Sources.Utils.Di;
using UnityEngine.Purchasing;

namespace Sources.Services.IapServices
{
    public interface IIapService : IService
    {
        bool IsInitialized { get; }
        event Action Initialized;
        string GetPriceString(IapProductType iapProductType);
        void InitiatePurchase(IapProductType iapProductType);
        event Action PurchaseProcessed;
        void RestorePurchases();
    }
}