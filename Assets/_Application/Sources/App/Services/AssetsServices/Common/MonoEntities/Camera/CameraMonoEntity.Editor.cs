using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using TriInspector;

namespace Sources.App.Services.AssetsServices.Common.MonoEntities.Camera
{
    public partial class CameraMonoEntity
    {
        [Button("Bake")]
        private void Bake()
        {
            base.OnValidate();
            
            _transform = GetComponent<SafeTransform>();
            _camera = GetComponent<SafeCamera>();
        }
    }
}