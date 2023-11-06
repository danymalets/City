using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.ShopScreens.GemsForCoinsExchanges
{
    public class CoinsForGemsItem : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI GemsText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI CoinsText { get; private set; }
        [field: SerializeField] public Button ExchangeButton { get; private set; }
    }
}