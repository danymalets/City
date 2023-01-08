using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views
{
    public class EnableDisableEntity : MonoBehaviour, IEnableDisableEntity
    {
        public void Enable() => 
            gameObject.Enable();

        public void Disable() =>
            gameObject.Disable();
    }
}