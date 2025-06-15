using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.App.Services.InputServices
{
    public class InputService : IInputService, IInitializable
    {
        private InputActions _inputAction;

        public InputService()
        {
        }

        public void Initialize()
        {
            _inputAction = new InputActions();
            _inputAction.Enable();
        }

        public Vector2 GetMove() => _inputAction.Player.Move.ReadValue<Vector2>();
        public bool WasEnterCarPressed() => _inputAction.Player.EnterCar.WasPressedThisFrame();

        public bool WasExitCarPressed() => _inputAction.Player.ExitCar.WasPressedThisFrame();
        public bool WasAndroidBackPressed() => Keyboard.current.escapeKey.wasPressedThisFrame;
    }
}