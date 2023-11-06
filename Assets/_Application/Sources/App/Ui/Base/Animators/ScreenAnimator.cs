using DG.Tweening;
using Sources.App.Ui.Base.Views;
using Sources.Utils.CommonUtils.Extensions;

namespace Sources.App.Ui.Base.Animators
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
                .AppendCallback(() => _gameScreen.gameObject.Enable());
            
            OnOpen(_animation);
            
            _animation
                .SetLink(_gameScreen.gameObject)
                .SetUpdate(true);
        }
        
        public void PlayClose(bool isForce)
        {
            _animation?.Complete();
            
            _animation = DOTween.Sequence()
                .AppendCallback(() => _gameScreen.gameObject.Enable());
            
            OnClose(_animation);
            
            _animation
                .AppendCallback(() => _gameScreen.gameObject.Disable())
                .SetLink(_gameScreen.gameObject)
                .SetUpdate(true);

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