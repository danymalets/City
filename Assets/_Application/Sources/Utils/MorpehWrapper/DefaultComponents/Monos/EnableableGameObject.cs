using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    public class EnableableGameObject : MonoBehaviour, IEnableableGameObject
    {
        public void Enable() =>
            gameObject.SetActive(true);

        public void Disable() =>
            gameObject.SetActive(false);
        
        public void SetActive(bool isActive) =>
            gameObject.SetActive(isActive);
    }
}