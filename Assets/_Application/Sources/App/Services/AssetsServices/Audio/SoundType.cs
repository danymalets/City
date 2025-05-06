using System;

namespace Sources.App.Services.AssetsServices.Audio
{
    [Serializable]
    public enum SoundType
    {
        ButtonClick = 1,
        SliderChangeValue = 2,
        PurchaseSuccess = 3,
        PurchaseError = 4,
    }
}