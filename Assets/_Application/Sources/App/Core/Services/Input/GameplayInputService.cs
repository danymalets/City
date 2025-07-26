using System;
using Sources.App.Services.InputServices;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.LevelScreens;
using Sources.App.Ui.Screens.LevelScreens.PlayerInputScreens;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Core.Services.Input
{
    public class GameplayInputService : IInitializable, IDisposable, IGameplayInputAccessService, IGameplayInputService
    {
        private readonly PlayerInputViewController _playerInputView;
        private readonly IInputService _inputService;

        public GameplayInputData GameplayInputData { get; } = new();

        public GameplayInputService()
        {
            _inputService = DiContainer.Resolve<IInputService>();

            LevelScreenController levelScreenController = DiContainer.Resolve<IUiControllersService>()
                .Get<LevelScreenController>();

            _playerInputView = levelScreenController.PlayerInputViewController;
        }

        void IInitializable.Initialize()
        {
            _playerInputView.JumpButtonClicked += OnJumpButtonClicked;
        }

        void IDisposable.Dispose()
        {
            _playerInputView.JumpButtonClicked -= OnJumpButtonClicked;
        }

        private void OnJumpButtonClicked()
        {
            GameplayInputData.WasJumpPressed = true;
        }

        void IGameplayInputService.Update()
        {
            GameplayInputData.PlayerMoveDirection = 
                _playerInputView.InputDirection != Vector2.zero ?
                    _playerInputView.InputDirection : 
                    _inputService.GetMove();

            GameplayInputData.WasJumpPressed |= _inputService.WasJumpPressed();
        }

        void IGameplayInputService.Reset()
        {
            GameplayInputData.WasJumpPressed = true;
        }
    }
}