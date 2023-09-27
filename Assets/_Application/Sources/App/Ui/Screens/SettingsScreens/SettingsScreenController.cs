using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using Sources.Services.UiServices.WindowBase.Screens;

namespace Sources.App.Ui.Screens.SettingsScreens
{
    public class SettingsScreenController : ScreenController
    {
        public SettingsScreenController(SettingsScreen settingsScreen) 
            : base(settingsScreen, new ToggleAnimator(settingsScreen))
        {
        }

        protected override void OnOpen()
        {
            
        }

        protected override void OnClose()
        {
            
        }

        protected override void OnRefresh()
        {
            
        }
    }
}