using System;

namespace Sources.Services.IapServices
{
    public enum IapProductType
    {
        Gems40,
        Gems220,
        Gems480,
        Gems1200,
        Gems2100,
        RedCar,
        GreenCar,
        RemoveAds,
    }

    public static class IapProductTypeUtility
    {
        public static long GetGemsCount(this IapProductType iapProductType) => iapProductType switch
        {
            IapProductType.Gems40 => 40,
            IapProductType.Gems220 => 220,
            IapProductType.Gems480 => 480,
            IapProductType.Gems1200 => 1200,
            IapProductType.Gems2100 => 2100,
            _ => throw new ArgumentOutOfRangeException(nameof(iapProductType), iapProductType, null)
        };
    }
}