using DG.Tweening;
using Sources.Services.UiServices.WindowBase.Screens;

namespace Sources.App.Ui.Controllers
{
    public class DefaultPopupAnimator : ScreenAnimator
    {
        public DefaultPopupAnimator(GameScreen gameScreen) : base(gameScreen)
        {
        }

        protected override void OnOpen(Sequence animation)
        {
            animation
                .Append(_gameScreen.transform.DOScale(1f, 0.3f).From(0.5f))
                .Append(_gameScreen.CanvasGroup.DOFade(1f, 0.3f).From(0f));
        }

        protected override void OnClose(Sequence animation)
        {
            animation
                .Append(_gameScreen.CanvasGroup.DOFade(0f, 0.3f).From(1f));
        }
    }
}