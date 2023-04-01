using Sources.App.Infrastructure.Services;
using UnityEngine;

namespace Sources.App.Infrastructure.ApplicationInput
{
    public class ApplicationInputService : IApplicationInputService
    {
        public int VerticalInput => (int)Input.GetAxisRaw("Vertical");
        public int HorizontalInput => (int)Input.GetAxisRaw("Horizontal");
        public bool GetKeyDown(KeyCode keyCode) => Input.GetKeyDown(keyCode);
    }

    public interface IApplicationInputService : IService
    {
        int VerticalInput { get; }
        int HorizontalInput { get; }
        bool GetKeyDown(KeyCode escape);
    }
}