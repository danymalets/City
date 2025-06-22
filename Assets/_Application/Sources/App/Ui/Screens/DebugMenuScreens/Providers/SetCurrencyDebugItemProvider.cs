using Cysharp.Threading.Tasks;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.Wallets;
using Sources.Utils.Di;
using TMPro;

namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.Providers
{
    public class SetCurrencyDebugItemProvider : DebugItemProvider
    {
        private readonly IUserAccessService _userAccessService;
        private readonly CurrencyType _currencyType;
        private readonly long _defaultValue;

        public SetCurrencyDebugItemProvider(CurrencyType currencyType, long defaultValue)
        {
            _defaultValue = defaultValue;
            _currencyType = currencyType;
            _userAccessService = DiContainer.Resolve<IUserAccessService>();
        }

        public override DebugExecutorItem GetItem()
        {
            return new DebugExecutorItem($"Set {_currencyType}",
                new DebugInputItem[] { new DebugInputFieldItem("Value", TMP_InputField.ContentType.IntegerNumber, _defaultValue) }, (input) =>
                {
                    if (int.TryParse(input[0], out int value))
                    {
                        _userAccessService.User.UserWallet.SetCurrency(_currencyType, value);
                        return UniTask.FromResult(new DebugExecutorResult(DebugResultStatus.Success));
                    }
                    else
                    {
                        return UniTask.FromResult(new DebugExecutorResult(DebugResultStatus.Failure,
                            $"Error parse int \"{input[0]}\""));
                    }
                });
        }
    }
}