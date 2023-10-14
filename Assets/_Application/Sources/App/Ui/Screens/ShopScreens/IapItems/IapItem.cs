using Sources.Services.IapServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.ShopScreens.IapItems
{
    public class IapItem : MonoBehaviour
    {
        [field: SerializeField] public Button Button { get; private set; }
        [field: SerializeField] public IapProductType IapProductType { get; private set; }
        [field: SerializeField] public TextMeshProUGUI TitleText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI PriceText { get; private set; }
        [field: SerializeField] public GameObject BoughtPanel { get; private set; }
        [field: SerializeField] public TextMeshProUGUI BoughtText { get; private set; }
    }
}