using System;
using Sources.App.Ui.Common.ToggleableImages;
using Sources.Utils.CommonUtils.Libs;

namespace Sources.App.Ui.Screens.SettingsScreens.SoundGroups
{
    public class SliderGroupController
    {
        private readonly SliderGroup _sliderGroup;
        private readonly Func<float> _getter;
        private readonly Action<float> _setter;
        private readonly ToggleableImageController _toggleableImageController;

        public SliderGroupController(SliderGroup sliderGroup, Func<float> getter, Action<float> setter)
        {
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
        }
        
        private void UpdateView(float value)
        {
            bool isEnabled = DMath.Greater(value, 0);
            
            _toggleableImageController.SetEnabled(isEnabled);
        }
    }
}