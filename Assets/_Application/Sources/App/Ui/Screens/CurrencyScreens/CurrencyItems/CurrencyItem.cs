using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.CurrencyScreens.CurrencyItems
{
    public class CurrencyItem : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI Text { get; private set; }
        [field: SerializeField] public Button BuyButton { get; private set; }
    }
}