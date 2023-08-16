using DG.Tweening;
using Sources.Services.UiServices.WindowBase.Screens;
using Sources.Utils.CommonUtils.Extensions;
using UnityEngine;

namespace Sources.App.Ui.Controllers
{
    public abstract class ScreenAnimator
    {
        protected readonly GameScreen _gameScreen;
        private Sequence _animation;

        protected ScreenAnimator(GameScreen gameScreen)
        {
            _gameScreen = gameScreen;
        }
        
        public void PlayOpen()
        {
            _animation?.Complete();
            
            _animation = DOTween.Sequence()
                .AppendCallback(() => _gameScreen.gameObject.Enable())
                .AppendCallback(() => _gameScreen.CanvasGroup.interactable = false);
            
            OnOpen(_animation);
            
            _animation
                .AppendCallback(() => _gameScreen.CanvasGroup.interactable = true)
                .SetLink(_gameScreen.gameObject);
        }
        
        public void PlayClose(bool isForce)
        {
            _animation?.Complete();
            
            _animation = DOTween.Sequence()
                .AppendCallback(() => _gameScreen.gameObject.Enable())
                .AppendCallback(() => _gameScreen.CanvasGroup.interactable = false);
            
            OnClose(_animation);
            
            _animation
                .AppendCallback(() => _gameScreen.gameObject.Disable())
                .SetLink(_gameScreen.gameObject);

            if (isForce)
            {
                _animation.Complete();
                _gameScreen.gameObject.Disable();
            }
        }

        protected abstract void OnOpen(Sequence animation);
        protected abstract void OnClose(Sequence animation);
    }
}