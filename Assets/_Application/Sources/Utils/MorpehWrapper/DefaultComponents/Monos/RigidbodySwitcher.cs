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

        public SafeRigidbody EnableRigidbodyInternal()
        {
#if FORCE_DEBUG
            DAssert.IsTrue(_rigidbody == null);
            DAssert.IsTrue(_safeRigidbody == null);
#endif

            _rigidbody = gameObject.AddComponent<Rigidbody>();
            _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            return _safeRigidbody = gameObject.AddComponent<SafeRigidbody>();
        }

        public void DisableRigidbodyInternal()
        {
#if FORCE_DEBUG
            DAssert.IsTrue(_rigidbody != null);
            DAssert.IsTrue(_safeRigidbody != null);
#endif

            _rigidbody.interpolation = RigidbodyInterpolation.None;
            DestroyImmediate(_safeRigidbody);
            DestroyImmediate(_rigidbody);
            _safeRigidbody = null;
            _rigidbody = null;
        }
    }
}