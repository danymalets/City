using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.InputServices
{
    public interface IInputService : IService
    {
        public Vector2 GetMove();
        public bool WasJumpPressed();
    }
}