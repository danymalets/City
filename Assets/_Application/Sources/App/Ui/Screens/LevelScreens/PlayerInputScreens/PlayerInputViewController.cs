using System;
using UnityEngine;

namespace Sources.App.Ui.Screens.LevelScreens.PlayerInputScreens
{
    public class PlayerInputViewController
    {
        private readonly PlayerInputView _playerInputView;

        public event Action EnterCarButtonClicked; 
        public event Action JumpButtonClicked; 
        
        public PlayerInputViewController(PlayerInputView playerInputView) 
        {
            _playerInputView = playerInputView;
        }

        public void OnOpen()
        {
            _playerInputView.EnterCarButton.onClick.AddListener(OnEnterCarButtonClicked);
            _playerInputView.JumpButton.onClick.AddListener(OnJumpButtonClicked);
        }

        private void OnEnterCarButtonClicked()
        {
            EnterCarButtonClicked?.Invoke();
        } 
        
        private void OnJumpButtonClicked()
        {
            JumpButtonClicked?.Invoke();
        }

        public Vector2 InputDirection => _playerInputView.Joystick.Direction;

        public void OnClose()
        {
            _playerInputView.EnterCarButton.onClick.RemoveListener(OnEnterCarButtonClicked);
            _playerInputView.JumpButton.onClick.RemoveListener(OnJumpButtonClicked);
        }

        public void SetActive(bool isActive)
        {
            _playerInputView.gameObject.SetActive(isActive);
        }

        public void SetEnterButtonActive(bool isActive)
        {
            _playerInputView.EnterCarButton.gameObject.SetActive(isActive);
        }
    }
}