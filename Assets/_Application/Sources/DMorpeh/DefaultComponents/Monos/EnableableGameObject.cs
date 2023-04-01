using Sources.DMorpeh.DefaultComponents.Views;
using UnityEngine;

namespace Sources.DMorpeh.DefaultComponents.Monos
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