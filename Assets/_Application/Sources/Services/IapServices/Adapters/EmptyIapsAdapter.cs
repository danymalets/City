using System;
using System.Collections.Generic;

namespace Sources.Services.IapServices
{
    public class EmptyIapsAdapter : IIapsAdapter
    {
        private Action<IapProductType> _onPurchaseProcess;

        public void InitiatePurchase(IapProductType iapProductType)
        {
            _onPurchaseProcess.Invoke(iapProductType);
        }

        public void Initialize(IEnumerable<IapProduct> products, Action<IapProductType> onPurchaseProcess)
        {
            _onPurchaseProcess = onPurchaseProcess;
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