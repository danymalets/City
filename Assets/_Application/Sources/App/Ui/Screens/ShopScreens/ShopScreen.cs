using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Common;
using Sources.App.Ui.Screens.ShopScreens.GemsForCoinsExchanges;
using Sources.App.Ui.Screens.ShopScreens.IapItems;
using TMPro;
using UnityEngine;

namespace Sources.App.Ui.Screens.ShopScreens
{
    public class ShopScreen : GameScreen
    {
        [field: Header("Title")]
        [field: SerializeField] public TextMeshProUGUI ShopTitle { get; private set; }        
        [field: Header("Restore Purchases")]
        [field: SerializeField] public TextButton RestorePurchasesTextButton { get; private set; }
        [field: Header("Gems For Coins")]
        [field: SerializeField] public CoinsForGemsItem[] CoinsForGemsItems { get; private set; }
        [field: Header("Iap Coins")]
        [field: SerializeField] public CurrencyIapItem[] IapGemItems { get; private set; }
        [field: Header("Iap Cars")]
        [field: SerializeField] public NamedIapItem IapRedCarItem { get; private set; }
        [field: SerializeField] public NamedIapItem GreenCarItem { get; private set; }
        [field: Header("Iap Ads")]
        [field: SerializeField] public NamedIapItem RemoveAdsItem { get; private set; }
    }
}