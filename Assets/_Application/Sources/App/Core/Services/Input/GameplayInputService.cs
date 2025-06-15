using System;
using Sources.App.Services.InputServices;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.LevelScreens;
using Sources.App.Ui.Screens.LevelScreens.CarInputScreens;
using Sources.App.Ui.Screens.LevelScreens.PlayerInputScreens;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Core.Services.Input
{
    public class GameplayInputService : IInitializable, IDisposable, IGameplayInputAccessService, IGameplayInputService
    {
        private readonly CarInputViewController _carInputView;
        private readonly PlayerInputViewController _playerInputView;
        private readonly IInputService _inputService;

        public GameplayInputData GameplayInputData { get; } = new();

        public GameplayInputService()
        {
            _inputService = DiContainer.Resolve<IInputService>();

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
                    _inputService.GetMove();
            
            GameplayInputData.CarMoveDirection = 
                _carInputView.InputDirection != Vector2.zero ?
                    _carInputView.InputDirection : 
                    _inputService.GetMove();

            GameplayInputData.WasCarEnterButtonPressed |= _inputService.WasEnterCarPressed();
            GameplayInputData.WasCarExitButtonPressed |= _inputService.WasExitCarPressed();
        }

        void IGameplayInputService.Reset()
        {
            GameplayInputData.WasCarEnterButtonPressed = false;
            GameplayInputData.WasCarExitButtonPressed = false;
            GameplayInputData.WasJumpPressed = false;
        }
    }
}