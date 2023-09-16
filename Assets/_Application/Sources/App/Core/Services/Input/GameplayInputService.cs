using System;
using Sources.App.Ui.Controllers;
using Sources.App.Ui.Screens.Input;
using Sources.Services.ApplicationInputServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Core.Services.Input
{
    public class GameplayInputService : IInitializable, IDisposable, IGameplayInputAccessService, IGameplayInputService
    {
        private readonly IApplicationInputService _applicationInput;
        private readonly CarInputScreenController _carInputScreen;
        private readonly PlayerInputScreenController _playerInputScreen;

        public GameplayInputData GameplayInputData { get; } = new();

        public GameplayInputService()
        {
            _applicationInput = DiContainer.Resolve<IApplicationInputService>();
            _carInputScreen = DiContainer.Resolve<IUiControllersService>()
                .Get<CarInputScreenController>();
            _playerInputScreen = DiContainer.Resolve<IUiControllersService>()
                .Get<PlayerInputScreenController>();
        }

        void IDisposable.Dispose()
        {
            _playerInputScreen.EnterCarButtonClicked += OnEnterCarButtonClicked;
            _carInputScreen.ExitCarButtonClicked += OnExitCarButtonClicked;
        }

        void IInitializable.Initialize()
        {
            _playerInputScreen.EnterCarButtonClicked += OnEnterCarButtonClicked;
            _carInputScreen.ExitCarButtonClicked += OnExitCarButtonClicked;
        }

        private void OnEnterCarButtonClicked()
        {
            GameplayInputData.WasCarEnterButtonClicked = true;
        }

        private void OnExitCarButtonClicked()
        {
            GameplayInputData.WasCarExitButtonClicked = true;
        }

        void IGameplayInputService.Update()
        {
            GameplayInputData.PlayerMoveDirection = 
                _playerInputScreen.InputDirection != Vector2.zero ?
                    _playerInputScreen.InputDirection : 
                    _applicationInput.DirectionInput;
            
            GameplayInputData.CarMoveDirection = 
                _carInputScreen.InputDirection != Vector2.zero ?
                    _carInputScreen.InputDirection : 
                    _applicationInput.DirectionInput;

            if (_applicationInput.GetKeyDown(KeyCode.E))
            {
                GameplayInputData.WasCarEnterButtonClicked = true;
            }
            
            if (_applicationInput.GetKeyDown(KeyCode.R))
            {
                GameplayInputData.WasCarExitButtonClicked = true;
            }
        }

        void IGameplayInputService.Reset()
        {
            GameplayInputData.WasCarEnterButtonClicked = false;
            GameplayInputData.WasCarExitButtonClicked = false;
        }
    }
}