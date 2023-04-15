using Sources.Services.Di;
using UnityEngine;

namespace Sources.Services.ApplicationInput
{
    public interface IApplicationInputService : IService
    {
        int VerticalInput { get; }
        int HorizontalInput { get; }
        bool GetKeyDown(KeyCode escape);
    }
}