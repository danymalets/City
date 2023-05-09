using UnityEngine;
using UnityEngine.UI;
using Screen = Sources.Services.UiServices.WindowBase.Screens.Screen;

namespace Sources.App.Ui.Screens
{
    public class LoadingScreen : Screen
    {
        [SerializeField]
        private Slider _progress;
        
        public void SetProgress(float progress) =>
            _progress.value = progress;
    }
}