using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.MonoEntities.Camera
{
    [RequireComponent(typeof(SafeTransform))]
    [RequireComponent(typeof(SafeCamera))]
    public partial class CameraMonoEntity : MonoEntity
    {
        [SerializeField]
        private SafeTransform _transform;
        
        [SerializeField]
        private SafeCamera _camera;
        
        public ITransform Transform => _transform;
        public ICamera Camera => _camera;
    }
}