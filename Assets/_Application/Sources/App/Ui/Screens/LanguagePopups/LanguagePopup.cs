using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Screens.LanguagePopups.LanguageItems;
using Sources.Services.PoolServices;
using TMPro;
using UnityEngine;

namespace Sources.App.Ui.Screens.LanguagePopups
{
    public class LanguagePopup : GamePopup
    {
        [field: SerializeField] public TextMeshProUGUI LanguageTitle { get; private set; }
        [field: SerializeField] public LanguageItem LanguageItemPrefab { get; private set; }
        [field: SerializeField] public Transform LanguageContent { get; private set; }
    }
}