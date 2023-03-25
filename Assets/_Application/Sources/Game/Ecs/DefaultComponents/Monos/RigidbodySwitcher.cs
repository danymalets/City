using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.DefaultComponents.Monos
{
    public class RigidbodySwitcher : MonoBehaviour, IRigidbodySwitcher
    {
        private Rigidbody _rigidbody;
        private SafeRigidbody _safeRigidbody;

        public SafeRigidbody EnableRigidbody()
        {
            if (_safeRigidbody != null)
                return _safeRigidbody;
            
            _rigidbody = gameObject.AddComponent<Rigidbody>();
            _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            return _safeRigidbody = gameObject.AddComponent<SafeRigidbody>();
        }

        public void DisableRigidbody()
        {
            _rigidbody.interpolation = RigidbodyInterpolation.None;
            Destroy(_rigidbody);
            Destroy(_safeRigidbody);
            _rigidbody = null;
            _safeRigidbody = null;
        }
    }
}