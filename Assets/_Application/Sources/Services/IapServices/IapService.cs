using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

namespace Sources.Services.IapServices
{
    public class IapService : IInitializable, IIapService
    {
        private readonly UnityIaps _unityIaps = new();
        private readonly IapProductExecutor _iapProductExecutor = new ();

        public bool IsInitialized => _unityIaps.IsInitialized;

        public event Action Initialized
        {
            add => _unityIaps.Initialized += value;
            remove => _unityIaps.Initialized -= value;
        }

        public string GetPriceString(IapProductType iapProductType) => 
            _unityIaps.GetPriceString(iapProductType);

        public void InitiatePurchase(IapProductType iapProductType) => 
            _unityIaps.InitiatePurchase(iapProductType);

        public event Action PurchaseProcessed;

        public void Initialize()
        {
            _unityIaps.Initialize(new[]
            {
                new IapProduct(IapProductType.Gems40, ProductType.Consumable, 0.99M,
                    IapsKeys.Gems40, IapsKeys.Gems40, IapsKeys.Gems40),
                
                new IapProduct(IapProductType.Gems220, ProductType.Consumable, 0.99M,
                    IapsKeys.Gems220, IapsKeys.Gems220, IapsKeys.Gems220),
                
                new IapProduct(IapProductType.Gems480, ProductType.Consumable, 0.99M,
                    IapsKeys.Gems480, IapsKeys.Gems480, IapsKeys.Gems480),
                
                new IapProduct(IapProductType.Gems1200, ProductType.Consumable, 0.99M,
                    IapsKeys.Gems1200, IapsKeys.Gems1200, IapsKeys.Gems1200),
                
                new IapProduct(IapProductType.Gems2100, ProductType.Consumable, 0.99M,
                    IapsKeys.Gems2100, IapsKeys.Gems2100, IapsKeys.Gems2100),
                
                new IapProduct(IapProductType.RedCar, ProductType.NonConsumable, 2.99M,
                    IapsKeys.RedCar, IapsKeys.RedCar, IapsKeys.RedCar),
                
                new IapProduct(IapProductType.GreenCar, ProductType.NonConsumable, 2.99M,
                    IapsKeys.GreenCar, IapsKeys.GreenCar, IapsKeys.GreenCar),
                
                new IapProduct(IapProductType.RemoveAds, ProductType.NonConsumable, 3.99M,
                    IapsKeys.RemoveAds, IapsKeys.RemoveAds, IapsKeys.RemoveAds),
                
            }, OnPurchaseProcess);
        }

        private void OnPurchaseProcess(IapProductType iapProductType)
        {
            _iapProductExecutor.ExecutePurchase(iapProductType);

            PurchaseProcessed();
        }

        public void RestorePurchases() => 
            _unityIaps.RestorePurchases(null,null);
    }
}