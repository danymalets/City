using System;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils;
using Sources.Utils.UiUtils;
using UnityEngine;

namespace Sources.App.Ui.Screens.LevelScreens.CarInputScreens
{
    public class CarInputViewController
    {
        private readonly CarInputView _carInputView;

        public event Action ExitCarButtonClicked;
        
        public CarInputViewController(CarInputView carInputView) 
        {
            _carInputView = carInputView;
        }

        public void OnOpen()
        {
            _carInputView.ExitCarButton.onClick.AddListener(OnExitCarButtonClicked);
        }

        public void OnClose()
        {
            _carInputView.ExitCarButton.onClick.RemoveListener(OnExitCarButtonClicked);
        }

        private void OnExitCarButtonClicked()
        {
            ExitCarButtonClicked();
        }

        public Vector2 InputDirection => 
            new (UiUtils.GetInputValue(_carInputView.LeftButton, 
                    _carInputView.RightButton),
                UiUtils.GetInputValue(_carInputView.UpButton,
                    _carInputView.DownButton));

        public void SetActive(bool isActive)
        {
            _carInputView.gameObject.SetActive(isActive);
        }
    }
}