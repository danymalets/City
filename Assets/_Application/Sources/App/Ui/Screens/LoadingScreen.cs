using Sources.Services.UiServices.WindowBase.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens
{
    public class LoadingScreen : GameScreen
    {
        [SerializeField]
        private Slider _progress;
        
        public void SetProgress(float progress) =>
            _progress.value = progress;
    }
}