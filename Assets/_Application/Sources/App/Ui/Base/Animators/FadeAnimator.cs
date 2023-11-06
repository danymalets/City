using DG.Tweening;
using Sources.App.Ui.Base.Views;

namespace Sources.App.Ui.Base.Animators
{
    public class FadeAnimator : ScreenAnimator
    {
        private readonly GameScreen _gamePopup;
        
        public FadeAnimator(GameScreen gamePopup) : base(gamePopup)
        {
        }

        protected override void OnOpen(Sequence animation)
        {
            animation
                .Append(_gameScreen.CanvasGroup.DOFade(1f, 0.2f).From(0f).SetEase(Ease.Linear));
        }

        protected override void OnClose(Sequence animation)
        {
            animation
                .Append(_gameScreen.CanvasGroup.DOFade(0f, 0.2f).From(1f).SetEase(Ease.Linear));
        }
    }
}