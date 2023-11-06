using TMPro;
using UnityEngine;

namespace Sources.App.Ui.Screens.ShopScreens.IapItems
{
    public class CurrencyIapItem : IapItem
    {
        [field: SerializeField] public TextMeshProUGUI CountText { get; private set; }
    }
}