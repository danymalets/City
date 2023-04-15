using _Application.Sources.Utils.Di;
using UnityEngine;

namespace _Application.Sources.CommonServices.ApplicationInputServices
{
    public interface IApplicationInputService : IService
    {
        int VerticalInput { get; }
        int HorizontalInput { get; }
        bool GetKeyDown(KeyCode escape);
    }
}