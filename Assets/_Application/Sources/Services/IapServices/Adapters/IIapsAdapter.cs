using System;
using System.Collections.Generic;

namespace Sources.Services.IapServices.Adapters
{
    internal interface IIapsAdapter
    {
        void InitiatePurchase(IapProductType iapProductType);
        void Initialize(IEnumerable<IapProduct> products, Action<IapProductType> onPurchaseProcess);
        void RestorePurchases(Action onCompleted, Action onFailed);
        bool IsInitialized { get; }
        Action Initialized { get; set; }
        bool TryGetPriceString(IapProductType iapProductType, out string price);
    }
}