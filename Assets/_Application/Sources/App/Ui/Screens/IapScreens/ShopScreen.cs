using Sources.App.Ui.Common;
using Sources.App.Ui.Screens.IapScreens.IapItems;
using Sources.Services.UiServices.WindowBase.Screens;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.IapScreens
{
    public class ShopScreen : GameScreen
    {
        [field: SerializeField] public TextMeshProUGUI ShopTitle { get; private set; }
        [field: SerializeField] public IapItem Buy500CoinsButton { get; private set; }
        [field: SerializeField] public IapItem Buy1000CoinsButton { get; private set; }
        [field: SerializeField] public IapItem BuyRedCarButton { get; private set; }
        [field: SerializeField] public IapItem BuyGreenCarButton { get; private set; }
        [field: SerializeField] public IapItem RemoveAdsButton { get; private set; }
        [field: SerializeField] public TextButton RestorePurchasesTextButton { get; private set; }
    }
}