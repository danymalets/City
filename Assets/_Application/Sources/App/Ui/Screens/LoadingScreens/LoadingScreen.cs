using Sources.App.Ui.Base.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.LoadingScreens
{
    public class LoadingScreen : GameScreen
    {
        [field: SerializeField] public Slider ProgressSlider { get; private set; }
    }
}