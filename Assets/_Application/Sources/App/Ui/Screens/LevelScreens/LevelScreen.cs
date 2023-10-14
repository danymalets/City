using Sources.App.Ui.Base.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.LevelScreens
{
    public class LevelScreen : GameScreen
    {
        [field: SerializeField] public Button ExitButton { get; private set; }
        [field: SerializeField] public Button RestartButton { get; private set; }
    }
}