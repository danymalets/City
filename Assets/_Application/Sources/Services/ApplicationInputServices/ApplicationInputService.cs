using UnityEngine;

namespace Sources.Services.ApplicationInputServices
{
    public class ApplicationInputService : IApplicationInputService
    {
        public float VerticalInput => Input.GetAxisRaw("Vertical");
        public float HorizontalInput => Input.GetAxisRaw("Horizontal");
        public Vector2 DirectionInput => new(HorizontalInput, VerticalInput);
        public bool GetKeyDown(KeyCode keyCode) => Input.GetKeyDown(keyCode);
    }
}