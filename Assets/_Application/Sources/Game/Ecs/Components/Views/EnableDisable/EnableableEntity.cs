using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.EnableDisable
{
    public class EnableableEntity : MonoBehaviour, IEnableableEntity
    {
        public void Enable() => 
            gameObject.Enable();

        public void Disable() =>
            gameObject.Disable();
    }
}