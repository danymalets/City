using JetBrains.Annotations;
using UnityEngine.Purchasing;

namespace Sources.Services.IapServices
{
    public class IapProduct
    {
        public string Id { get; }
        public IapProductType IapProductType { get; }
        public ProductType ProductType { get; }
        [CanBeNull] public string AndroidId { get; }
        [CanBeNull] public string IosId { get; }
        public decimal DefaultCost { get; }

        public IapProduct(IapProductType iapProductType, ProductType productType, decimal defaultCost, string id, [CanBeNull] string androidId, [CanBeNull] string iosId)
        {
            Id = id;
            AndroidId = androidId;
            IosId = iosId;
            ProductType = productType;
            IapProductType = iapProductType;
            DefaultCost = defaultCost;
        }
    }
}