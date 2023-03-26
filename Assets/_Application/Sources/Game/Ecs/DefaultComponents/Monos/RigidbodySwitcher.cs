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
            DAssert.IsTrue(_rigidbody == null);
            DAssert.IsTrue(_safeRigidbody == null);
            
            _rigidbody = gameObject.AddComponent<Rigidbody>();
            _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            return _safeRigidbody = gameObject.AddComponent<SafeRigidbody>();
        }

        public void DisableRigidbody()
        {
            DAssert.IsTrue(_rigidbody != null);
            DAssert.IsTrue(_safeRigidbody != null);
            
            _rigidbody.interpolation = RigidbodyInterpolation.None;
            DestroyImmediate(_rigidbody);
            DestroyImmediate(_safeRigidbody);
            _rigidbody = null;
            _safeRigidbody = null;
        }
    }
}