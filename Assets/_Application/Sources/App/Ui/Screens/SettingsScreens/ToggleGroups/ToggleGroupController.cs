using System;
using Sources.App.Services.AssetsServices.Audio;
using Sources.App.Services.AudioServices;
using Sources.App.Ui.Common.CustomToggles;
using Sources.App.Ui.Common.ToggleableImages;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.SettingsScreens.ToggleGroups
{
    public class ToggleGroupController
    {
        private readonly Action<bool> _setter;
        private readonly Func<bool> _getter;
        private readonly ToggleableImageController _toggleableImageController;
        private readonly CustomToggleController _toggleController;
        private readonly IAudioService _audioService;

        public ToggleGroupController(ToggleGroup toggleGroup, Func<bool> getter, Action<bool> setter)
        {
            _audioService = DiContainer.Resolve<IAudioService>();

            _toggleableImageController = new ToggleableImageController(toggleGroup.ToggleableImage);
            _toggleController = new CustomToggleController(toggleGroup.Toggle);
            _getter = getter;
            _setter = setter;
        }
        
        public void OnSetup()
        {
            UpdateView(_getter());
            _toggleController.OnSetup();

            _toggleController.Clicked += ToggleGroupController_OnClicked;
        }

        public void OnCleanup()
        {
            _toggleController.OnCleanup();
            _toggleController.Clicked -= ToggleGroupController_OnClicked;
        }

        private void ToggleGroupController_OnClicked()
        {
            bool value = !_getter();
            _setter(value);
            UpdateView(value);
            _audioService.PlayOnce(SoundType.ButtonClick);
        }
        
        private void UpdateView(bool value)
        {
            _toggleableImageController.SetEnabled(value);
            _toggleController.SetEnabled(value);
        }
    }
}