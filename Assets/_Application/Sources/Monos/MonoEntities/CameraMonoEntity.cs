using Sirenix.OdinInspector;
using Sources.App.Data.MonoEntities;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Monos.MonoEntities
{
    [RequireComponent(typeof(SafeTransform))]
    [RequireComponent(typeof(SafeCamera))]
    public class CameraMonoEntity : MonoEntity, ICameraMonoEntity
    {
        [SerializeField]
        private SafeTransform _transform;
        
        [SerializeField]
        private SafeCamera _camera;
        
        public ITransform Transform => _transform;
        public ICamera Camera => _camera;

        [Button("Bake", ButtonSizes.Large)]
        private void Bake()
        {
            base.OnValidate();
            
            _transform = GetComponent<SafeTransform>();
            _camera = GetComponent<SafeCamera>();
        }
    }
}