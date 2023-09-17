using Sources.Services.UiServices.WindowBase.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.LoadingScreens
{
    public class LoadingScreen : GameScreen
    {
        [field: SerializeField] public Slider ProgressSlider { get; private set; }
    }
}