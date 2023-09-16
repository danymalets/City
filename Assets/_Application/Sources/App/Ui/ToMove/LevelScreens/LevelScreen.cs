using Sources.App.Ui.Screens.Level;
using Sources.Services.UiServices.WindowBase.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.ToMove.LevelScreens
{
    public class LevelScreen : GameScreen
    {
        [field: SerializeField] public Button ExitButton { get; private set; }
        [field: SerializeField] public Button RestartButton { get; private set; }
        [field: SerializeField] public CoinsView CoinsView { get; private set; }
    }
}