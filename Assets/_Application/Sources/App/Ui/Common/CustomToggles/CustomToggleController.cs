using System;
using Sources.Utils.CommonUtils.Data.Live;

namespace Sources.App.Ui.Common.CustomToggles
{
    public class CustomToggleController
    {
        private readonly CustomToggle _customToggle;
        
        public event Action Clicked;

        public CustomToggleController(CustomToggle customToggle)
        {
            _customToggle = customToggle;
        }

        public void OnSetup()
        {
            _customToggle.Button.onClick.AddListener(OnClicked);
        }

        public void OnCleanup()
        {
            _customToggle.Button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            Clicked();
        }

        public void SetEnabled(bool isEnabled)
        {
            _customToggle.OnContent.SetActive(isEnabled);
            _customToggle.OffContent.SetActive(!isEnabled);
        }
    }
}