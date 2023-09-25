using Sources.App.Ui.Screens.CurrencyScreens.CurrencyItems;
using Sources.Services.UiServices.WindowBase.Screens;
using UnityEngine;

namespace Sources.App.Ui.Screens.CurrencyScreens
{
    public class CurrencyScreen : GameScreen
    {
        [field: SerializeField] public CurrencyItem CoinsItem { get; private set; }
    }
}