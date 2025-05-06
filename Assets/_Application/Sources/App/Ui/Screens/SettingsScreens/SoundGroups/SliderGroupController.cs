using System;
using Sources.App.Services.AssetsServices.Audio;
using Sources.App.Services.AudioServices;
using Sources.App.Ui.Common.ToggleableImages;
using Sources.Services.TimeServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.SettingsScreens.SoundGroups
{
    public class SliderGroupController
    {
        private const float MinSliderDelay = 0.1f;

        private readonly SliderGroup _sliderGroup;
        private readonly Func<float> _getter;
        private readonly Action<float> _setter;
        private readonly ToggleableImageController _toggleableImageController;
        private readonly IAudioService _audioService;
        private readonly ITimeService _timeService;
        private double _lastPlayedSoundTime;

        public SliderGroupController(SliderGroup sliderGroup, Func<float> getter, Action<float> setter)
        {
            _audioService = DiContainer.Resolve<IAudioService>();
            _timeService = DiContainer.Resolve<ITimeService>();
            _sliderGroup = sliderGroup;
            _getter = getter;
            _setter = setter;
            _toggleableImageController = new ToggleableImageController(_sliderGroup.ToggleableImage);
        }

        public void OnSetup()
        {
            float value = _getter();
            UpdateView(value);
            _sliderGroup.Slider.value = value;
            _sliderGroup.Slider.onValueChanged.AddListener(Slider_OnValueChanged);
        }

        public void OnCleanup()
        {
            _sliderGroup.Slider.onValueChanged.RemoveListener(Slider_OnValueChanged);
        }

        private void Slider_OnValueChanged(float value)
        {
            UpdateView(value);
            _setter(value);
            if (_timeService.Time > _lastPlayedSoundTime + MinSliderDelay)
            {
                _audioService.PlayOnce(SoundType.SliderChangeValue);
                _lastPlayedSoundTime = _timeService.Time;
            }
        }


        private void UpdateView(float value)
        {
            bool isEnabled = MathUtils.Greater(value, 0);
            
            _toggleableImageController.SetEnabled(isEnabled);
        }
    }
}