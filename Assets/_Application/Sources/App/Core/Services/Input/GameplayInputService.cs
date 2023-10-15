using System;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.LevelScreens;
using Sources.App.Ui.Screens.LevelScreens.CarInputScreens;
using Sources.App.Ui.Screens.LevelScreens.PlayerInputScreens;
using Sources.Services.ApplicationInputServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Core.Services.Input
{
    public class GameplayInputService : IInitializable, IDisposable, IGameplayInputAccessService, IGameplayInputService
    {
        private readonly IApplicationInputService _applicationInput;
        private readonly CarInputViewController _carInputView;
        private readonly PlayerInputViewController _playerInputView;

        public GameplayInputData GameplayInputData { get; } = new();

        public GameplayInputService()
        {
            _applicationInput = DiContainer.Resolve<IApplicationInputService>();

            LevelScreenController levelScreenController = DiContainer.Resolve<IUiControllersService>()
                .Get<LevelScreenController>();

            _carInputView = levelScreenController.CarInputViewController;
            _playerInputView = levelScreenController.PlayerInputViewController;
        }

        void IInitializable.Initialize()
        {
            _playerInputView.EnterCarButtonClicked += OnEnterCarButtonClicked;
            _playerInputView.JumpButtonClicked += OnJumpButtonClicked;
            _carInputView.ExitCarButtonClicked += OnExitCarButtonClicked;
        }

        void IDisposable.Dispose()
        {
            _playerInputView.EnterCarButtonClicked -= OnEnterCarButtonClicked;
            _playerInputView.JumpButtonClicked -= OnJumpButtonClicked;
            _carInputView.ExitCarButtonClicked -= OnExitCarButtonClicked;
        }

        private void OnJumpButtonClicked()
        {
            GameplayInputData.WasJumpPressed = true;
        }

        private void OnEnterCarButtonClicked()
        {
            GameplayInputData.WasCarEnterButtonPressed = true;
        }

        private void OnExitCarButtonClicked()
        {
            GameplayInputData.WasCarExitButtonPressed = true;
        }

        void IGameplayInputService.Update()
        {
            GameplayInputData.PlayerMoveDirection = 
                _playerInputView.InputDirection != Vector2.zero ?
                    _playerInputView.InputDirection : 
                    _applicationInput.DirectionInput;
            
            GameplayInputData.CarMoveDirection = 
                _carInputView.InputDirection != Vector2.zero ?
                    _carInputView.InputDirection : 
                    _applicationInput.DirectionInput;

            if (_applicationInput.GetKeyDown(KeyCode.E))
            {
                GameplayInputData.WasCarEnterButtonPressed = true;
            }
            
            if (_applicationInput.GetKeyDown(KeyCode.R))
            {
                GameplayInputData.WasCarExitButtonPressed = true;
            }
        }

        void IGameplayInputService.Reset()
        {
            GameplayInputData.WasCarEnterButtonPressed = false;
            GameplayInputData.WasCarExitButtonPressed = false;
            GameplayInputData.WasJumpPressed = false;
        }
    }
}