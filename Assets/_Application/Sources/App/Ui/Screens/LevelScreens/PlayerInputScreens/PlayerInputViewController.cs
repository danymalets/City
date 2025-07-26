using System;
using UnityEngine;

namespace Sources.App.Ui.Screens.LevelScreens.PlayerInputScreens
{
    public class PlayerInputViewController
    {
        private readonly PlayerInputView _playerInputView;

        public event Action JumpButtonClicked; 
        
        public PlayerInputViewController(PlayerInputView playerInputView) 
        {
            _playerInputView = playerInputView;
        }

        public void OnOpen()
        {
            _playerInputView.JumpButton.onClick.AddListener(OnJumpButtonClicked);
        }

        private void OnJumpButtonClicked()
        {
            JumpButtonClicked?.Invoke();
        }

        public Vector2 InputDirection => _playerInputView.Joystick.Direction;

        public void OnClose()
        {
            _playerInputView.JumpButton.onClick.RemoveListener(OnJumpButtonClicked);
        }
    }
}