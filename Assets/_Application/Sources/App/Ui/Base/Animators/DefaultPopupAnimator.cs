using DG.Tweening;
using Sources.App.Ui.Base.Views;

namespace Sources.App.Ui.Base.Animators
{
    public class DefaultPopupAnimator : ScreenAnimator
    {
        private readonly GamePopup _gamePopup;
        
        public DefaultPopupAnimator(GamePopup gamePopup) : base(gamePopup)
        {
            _gamePopup = gamePopup;
        }

        protected override void OnOpen(Sequence animation)
        {
            animation
                .Append(_gamePopup.Content.DOScale(1f, 0.3f).From(0.5f))
                .Append(_gameScreen.CanvasGroup.DOFade(1f, 0.3f).From(0f));
        }

        protected override void OnClose(Sequence animation)
        {
            animation
                .Append(_gameScreen.CanvasGroup.DOFade(0f, 0.3f).From(1f));
        }
    }
}