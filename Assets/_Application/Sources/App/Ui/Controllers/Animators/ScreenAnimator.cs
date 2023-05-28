using DG.Tweening;
using Sources.Services.UiServices.WindowBase.Screens;
using UnityEngine;

namespace Sources.App.Ui.Controllers
{
    public abstract class ScreenAnimator
    {
        protected ScreenAnimator(ScreenBase gameScreen)
        {
            
        }
        
        public Sequence GetAnimation()
        {
            Sequence animation = DOTween.Sequence();
            //     .AppendCallback(() => gameScreen..Enable())
            //     .AppendCallback(() => _canvasGroup.interactable = false);
            //
            // OnAnimation(animation);
            //
            // animation
            //     .AppendCallback(() => _canvasGroup.interactable = true)
            //     .SetLink(_gameObject);
            //
            ;return animation;
        }

    }
}