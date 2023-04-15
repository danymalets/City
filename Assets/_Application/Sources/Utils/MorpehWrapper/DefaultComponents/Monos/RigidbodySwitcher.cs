using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    [RequireComponent(typeof(PhysicsEventsReceiver))]
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