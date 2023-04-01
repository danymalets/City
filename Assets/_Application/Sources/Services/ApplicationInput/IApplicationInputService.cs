using Sources.Di;
using UnityEngine;

namespace _Application.Sources.Services.ApplicationInput
{
    public interface IApplicationInputService : IService
    {
        int VerticalInput { get; }
        int HorizontalInput { get; }
        bool GetKeyDown(KeyCode escape);
    }
}