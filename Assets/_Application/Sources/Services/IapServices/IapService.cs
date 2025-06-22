using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Services.IapServices.Adapters;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

namespace Sources.Services.IapServices
{
    public class IapService : IInitializable, IIapService
    {
        private static IapProduct[] Products = new[]
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

            new IapProduct(IapProductType.GoldChest, ProductType.NonConsumable, 2.99M,
                IapsKeys.RedCar, IapsKeys.RedCar, IapsKeys.RedCar),

            new IapProduct(IapProductType.SilverChest, ProductType.NonConsumable, 2.99M,
                IapsKeys.GreenCar, IapsKeys.GreenCar, IapsKeys.GreenCar),

            new IapProduct(IapProductType.RemoveAds, ProductType.NonConsumable, 3.99M,
                IapsKeys.RemoveAds, IapsKeys.RemoveAds, IapsKeys.RemoveAds),

        };
        
        private readonly IIapsAdapter _iapsAdapter;
        private readonly IapProductExecutor _iapProductExecutor = new ();
        private Dictionary<IapProductType, decimal> _defaultCosts;

        public bool IsInitialized => _iapsAdapter.IsInitialized;
        
        public IapService()
        {
            _iapsAdapter = new EmptyIapsAdapter();
            _iapProductExecutor = new IapProductExecutor();
        }

        public event Action Initialized
        {
            add => _iapsAdapter.Initialized += value;
            remove => _iapsAdapter.Initialized -= value;
        }

        public void Initialize()
        {
            _defaultCosts = Products.ToDictionary(p => p.IapProductType, p => p.DefaultCost);
            _iapsAdapter.Initialize(Products, OnPurchaseProcess);
        }

        public string GetPriceString(IapProductType iapProductType)
        {
            if (_iapsAdapter.TryGetPriceString(iapProductType, out string price))
            {
                return price;
            }
            else
            {
                return $"{_defaultCosts[iapProductType]}$";
            }
        }

        public void InitiatePurchase(IapProductType iapProductType) => 
            _iapsAdapter.InitiatePurchase(iapProductType);

        public event Action PurchaseProcessed;

        private void OnPurchaseProcess(IapProductType iapProductType)
        {
            _iapProductExecutor.ExecutePurchase(iapProductType);

            PurchaseProcessed?.Invoke();
        }

        public void RestorePurchases() => 
            _iapsAdapter.RestorePurchases(null,null);
    }
}