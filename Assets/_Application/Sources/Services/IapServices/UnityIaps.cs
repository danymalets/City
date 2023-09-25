using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Services.ApplicationServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

namespace Sources.Services.IapServices
{
    public class UnityIaps : IDetailedStoreListener
    {
        private IReadOnlyDictionary<string, IapProductType> _productsByIds;
        private IReadOnlyDictionary<IapProductType, Product> _products;
        private IExtensionProvider _extensions;
        private IStoreController _controller;
        private readonly IApplicationService _applicationService;
        private Action<IapProductType> _onPurchaseProcess;
        private Dictionary<IapProductType, decimal> _defaultConsts;
        
        public bool IsInitialized { get; set; }
        public event Action Initialized;
        
        public UnityIaps()
        {
            _applicationService = DiContainer.Resolve<IApplicationService>();
        }

        public void Initialize(IEnumerable<IapProduct> products, Action<IapProductType> onPurchaseProcess)
        {
            _onPurchaseProcess = onPurchaseProcess;
            
            _productsByIds = products.ToDictionary(p => p.Id, p => p.IapProductType);

            _defaultConsts = products.ToDictionary(p => p.IapProductType, p => p.DefaultCost);

            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            foreach (IapProduct product in products)
            {
                IDs ids = new();

                if (product.AndroidId != null)
                {
                    ids.Add(product.AndroidId, GooglePlay.Name);
                }

                if (product.IosId != null)
                {
                    ids.Add(product.IosId, AppleAppStore.Name);
                }
                
                builder.AddProduct(product.Id, product.ProductType);
            }

            UnityPurchasing.Initialize(this, builder);
        }

        public void InitiatePurchase(IapProductType iapProductType)
        {
            if (IsInitialized)
            {
                Debug.Log($"[Iaps] InitiatePurchase Success");

                _controller.InitiatePurchase(_products[iapProductType]);
            }
            else
            {
                Debug.Log($"[Iaps] InitiatePurchase Error (not initialized)");
            }
        }
        
        public void RestorePurchases(Action onCompleted, Action onFailed)
        {
            if (!IsInitialized)
            {
                return;
            }

            if (_applicationService.ApplicationPlatform == RuntimePlatform.IPhonePlayer)
            {
                Debug.Log($"[IapService] StartRestoreIOS");

                _extensions.GetExtension<IAppleExtensions>().RestoreTransactions((isSuccess, message) =>
                {
                    if (isSuccess)
                    {
                        Debug.Log($"[IapService] Restore Success");

                        onCompleted?.Invoke();
                    }
                    else
                    {
                        Debug.Log($"[IapService] Restore Error message:{message}");

                        onFailed?.Invoke();
                    }
                });
            }
        }

        void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            Debug.Log($"[IapService] OnInitialized [{string.Join(",", controller.products.all.Select(p => p.definition.id))}]");
            
            _products = controller.products.all.ToDictionary(p => _productsByIds[p.definition.id], p => p);

            _controller = controller;
            _extensions = extensions;
            
            IsInitialized = true;
            
            Initialized?.Invoke();
        }

        void IStoreListener.OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.Log($"[IapService] OnInitializeFailed error:{error}");
        }

        void IStoreListener.OnInitializeFailed(InitializationFailureReason error, string message)
        {
            Debug.Log($"[IapService] OnInitializeFailed error:{error} message:{message}");
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEventArgs)
        {
            Debug.Log($"[IapService] PurchaseCompleted " +
                      $"purchaseEventArgs.purchasedProduct.definition.id:{purchaseEventArgs.purchasedProduct.definition.id}");
            
            _onPurchaseProcess(_productsByIds[purchaseEventArgs.purchasedProduct.definition.id]);
            
            return PurchaseProcessingResult.Complete;
        }

        void IStoreListener.OnPurchaseFailed(Product product, PurchaseFailureReason purchaseFailureReason)
        {
            Debug.Log($"[IapService] OnPurchaseFailed product.transactionID:{product.transactionID} " +
                      $"product.localizedTitle:{product.metadata.localizedTitle}" +
                      $"failureDescription:{purchaseFailureReason}");
        }

        void IDetailedStoreListener.OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
        {
            Debug.Log($"[IapService] OnPurchaseFailed product.transactionID:{product.transactionID}\n" +
                      $"product.localizedTitle:{product.metadata.localizedTitle}\n" +
                      $"failureDescription.reason:{failureDescription.reason}\n" +
                      $"failureDescription.message:{failureDescription.message}");
        }

        public string GetPriceString(IapProductType iapProductType)
        {
            if (IsInitialized)
            {
                return _products[iapProductType].metadata.localizedPriceString;
            }
            else
            {
                return $"{_defaultConsts[iapProductType]}$";
            }
        }
    }
}