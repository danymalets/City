using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Screens.CurrencyScreens.CurrencyItems;
using UnityEngine;

namespace Sources.App.Ui.Screens.CurrencyScreens
{
    public class CurrencyScreen : GameScreen
    {
        [field: SerializeField] public CurrencyItem CoinsItem { get; private set; }
        [field: SerializeField] public CurrencyItem GemsItem { get; private set; }
    }
}