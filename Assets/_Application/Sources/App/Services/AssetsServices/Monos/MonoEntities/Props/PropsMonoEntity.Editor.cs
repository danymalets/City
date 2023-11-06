using Sirenix.OdinInspector;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;

namespace Sources.App.Services.AssetsServices.Monos.MonoEntities.Props
{
    public partial class PropsMonoEntity
    {
        [Button("Force Validate", ButtonSizes.Large)]
        protected override void OnValidate()
        {
            base.OnValidate();
            _colliders = GetComponentsInChildren<SafeColliderBase>();
            _safeTransform = GetComponent<SafeTransform>();
            _rigidbodySwitcher = GetComponent<RigidbodySwitcher>();
        }
    }
}