using Sirenix.OdinInspector;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;

namespace Sources.App.Services.AssetsServices.Monos.MonoEntities.Camera
{
    public partial class CameraMonoEntity
    {
        [Button("Bake", ButtonSizes.Large)]
        private void Bake()
        {
            base.OnValidate();
            
            _transform = GetComponent<SafeTransform>();
            _camera = GetComponent<SafeCamera>();
        }
    }
}