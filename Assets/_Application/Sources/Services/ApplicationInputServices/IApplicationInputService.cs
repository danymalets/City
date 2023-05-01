using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.ApplicationInputServices
{
    public interface IApplicationInputService : IService
    {
        int VerticalInput { get; }
        int HorizontalInput { get; }
        bool GetKeyDown(KeyCode escape);
    }
}