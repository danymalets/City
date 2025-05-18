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
            switch (iapProductType)
            {
                case IapProductType.Gems40:
                    _userAccessService.User.UserWallet.Gems.AddCurrency(iapProductType.GetGemsCount());
                    break;
                case IapProductType.Gems220:
                    _userAccessService.User.UserWallet.Gems.AddCurrency(iapProductType.GetGemsCount());
                    break;
                case IapProductType.Gems480:
                    _userAccessService.User.UserWallet.Gems.AddCurrency(iapProductType.GetGemsCount());
                    break;
                case IapProductType.Gems1200:
                    _userAccessService.User.UserWallet.Gems.AddCurrency(iapProductType.GetGemsCount());
                    break;
                case IapProductType.Gems2100:
                    _userAccessService.User.UserWallet.Gems.AddCurrency(iapProductType.GetGemsCount());
                    break;
                case IapProductType.SilverChest:
                    _userAccessService.User.UserProgress.IsGreenCarUnlocked = true;
                    break;
                case IapProductType.GoldChest:
                    _userAccessService.User.UserProgress.IsRedCarUnlocked = true;
                    break;
                case IapProductType.RemoveAds:
                    _userAccessService.User.UserProgress.IsRemoveAds = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(iapProductType), iapProductType, null);
            }
        }
    }
}