using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.DebugMenuScreens
{
    public class DebugMenuScreen : GameScreen
    {
        [field: SerializeField] public Button DebugMenuButton { get; private set; }
        [field: SerializeField] public DebugMenuView DebugMenu { get; private set; }
    }
}