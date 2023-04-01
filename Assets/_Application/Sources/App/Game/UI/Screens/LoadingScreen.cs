using Sources.Di;
using Sources.User;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Game.UI.Screens
{
    public class LoadingScreen : WindowBase.Screens.Screen
    {
        private const float SceneLoadProgress = 1f / 3f;
        private const float CheckQualityProgress = 2f / 3f;
        
        [SerializeField]
        private Slider _progress;

        private bool _withCheckQuality;

        protected override void OnOpen()
        {
            User.User user = DiContainer.Resolve<IUserAccessService>().User;
            _withCheckQuality = user.Preferences.BestQualityForDevice == null;
        }

        public void SetSceneLoadProgress(float progress) =>
            _progress.value = Mathf.Lerp(0, SceneLoadProgress, progress);
        
        public void SetFirstGameTimeProgress(float progress) =>
            _progress.value = Mathf.Lerp(SceneLoadProgress, CheckQualityProgress, progress);  
        
        public void SetSecondGameTimeProgress(float progress) =>
            _progress.value = Mathf.Lerp(CheckQualityProgress, 1f, progress);
    }
}