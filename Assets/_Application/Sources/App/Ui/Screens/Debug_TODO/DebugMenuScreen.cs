using Sources.App.Ui.Base.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.Debug_TODO
{
    public class DebugMenuScreen : GameScreen
    {
        [field: SerializeField] public Button OpenDebugMenuButton { get; private set; }
    }
}