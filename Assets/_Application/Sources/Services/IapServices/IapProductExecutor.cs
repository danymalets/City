using System;
using Sources.App.Services.UserServices;
using Sources.Utils.Di;

namespace Sources.Services.IapServices
{
    public class IapProductExecutor
    {
        private readonly IUserAccessService _userAccessService;
        private readonly IUserSaveService _userSaveService;

        public IapProductExecutor()
        {
            _userAccessService = DiContainer.Resolve<IUserAccessService>();
            _userSaveService = DiContainer.Resolve<IUserSaveService>();
        }

        public void ExecutePurchase(IapProductType iapProductType)
        {
            ApplyPurchase(iapProductType);
            
            _userSaveService.Save();
        }

        private void ApplyPurchase(IapProductType iapProductType)
        {
            if (iapProductType == IapProductType.Coins500)
            {
                _userAccessService.User.Wallet.Coins.AddCurrency(500);
            }
            else if (iapProductType == IapProductType.Coins1000)
            {
                _userAccessService.User.Wallet.Coins.AddCurrency(1000);
            }
            else if (iapProductType == IapProductType.RedCar)
            {
                _userAccessService.User.Progress.IsRedCarUnlocked = true;
            }
            else if (iapProductType == IapProductType.GreenCar)
            {
                _userAccessService.User.Progress.IsGreenCarUnlocked = true;
            }
            else if (iapProductType == IapProductType.RemoveAds)
            {
                _userAccessService.User.IsRemoveAds = true;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(iapProductType), iapProductType, null);
            }
        }
    }
}