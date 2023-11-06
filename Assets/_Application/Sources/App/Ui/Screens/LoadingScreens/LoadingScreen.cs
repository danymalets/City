using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.LoadingScreens
{
    public class LoadingScreen : GameScreen
    {
        [field: SerializeField] public TextSlider ProgressSlider { get; private set; }
    }
}