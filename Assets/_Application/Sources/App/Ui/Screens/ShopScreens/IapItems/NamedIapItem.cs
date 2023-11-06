using TMPro;
using UnityEngine;

namespace Sources.App.Ui.Screens.ShopScreens.IapItems
{
    public class NamedIapItem : IapItem
    {
        [field: SerializeField] public TextMeshProUGUI TitleText { get; private set; }
    }
}