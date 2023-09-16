using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.ApplicationInputServices
{
    public interface IApplicationInputService : IService
    {
        float VerticalInput { get; }
        float HorizontalInput { get; }
        Vector2 DirectionInput { get; }
        bool GetKeyDown(KeyCode escape);
    }
}