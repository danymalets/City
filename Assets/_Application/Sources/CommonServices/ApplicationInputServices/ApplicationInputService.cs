using UnityEngine;

namespace Sources.CommonServices.ApplicationInputServices
{
    public class ApplicationInputService : IApplicationInputService
    {
        public int VerticalInput => (int)Input.GetAxisRaw("Vertical");
        public int HorizontalInput => (int)Input.GetAxisRaw("Horizontal");
        public bool GetKeyDown(KeyCode keyCode) => Input.GetKeyDown(keyCode);
    }
}