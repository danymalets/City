using JetBrains.Annotations;
using Sources.Services.IapServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.ShopScreens.IapItems
{
    public abstract class IapItem : MonoBehaviour
    {
        [field: SerializeField] public Button Button { get; private set; }
        [field: SerializeField] public TextMeshProUGUI PriceText { get; private set; }
    }
}