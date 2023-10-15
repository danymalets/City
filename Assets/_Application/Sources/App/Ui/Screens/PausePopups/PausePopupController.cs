using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Base.Views;

namespace Sources.App.Ui.Screens.PausePopups
{
    public class PausePopupController : ScreenController
    {
        private readonly PausePopup _pausePopup;

        public PausePopupController(PausePopup pausePopup) 
            : base(pausePopup, new DefaultPopupAnimator(pausePopup))
        {
            _pausePopup = pausePopup;
        }

        protected override void OnRefresh()
        {
            
        }

        protected override void OnClose()
        {
        }

        protected override void OnOpen()
        {
        }
    }
}