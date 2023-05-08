using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    public class SafeComponent<TUnsafe> : MonoBehaviour
        where TUnsafe : Component
    {
        [SerializeField]
        private TUnsafe _unsafe;

        protected TUnsafe Unsafe =>
            ReferenceEquals(_unsafe, null)
                ? _unsafe = GetComponent<TUnsafe>()
                : _unsafe;

        private void OnValidate()
        {
            _unsafe = GetComponent<TUnsafe>();
        }
    }
}