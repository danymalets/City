using System;
using System.Collections.Generic;

namespace Sources.Services.IapServices
{
    public class EmptyIapsAdapter : IIapsAdapter
    {

        public void InitiatePurchase(IapProductType iapProductType) { }

        public void Initialize(IEnumerable<IapProduct> products, Action<IapProductType> onPurchaseProcess)
        {
            Initialized?.Invoke();
        }

        public void RestorePurchases(Action onCompleted, Action onFailed) { }
        public bool IsInitialized => true;
        public Action Initialized { get; set; }
        public bool TryGetPriceString(IapProductType iapProductType, out string price)
        {
            price = null;
            return false;
        }
    }
}