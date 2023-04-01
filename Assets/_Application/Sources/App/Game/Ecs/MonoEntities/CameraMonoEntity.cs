using Sirenix.OdinInspector;
using Sources.App.DMorpeh;
using Sources.App.Game.Ecs.DefaultComponents.Monos;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Game.Ecs.MonoEntities
{
    [RequireComponent(typeof(SafeTransform))]
    [RequireComponent(typeof(SafeCamera))]
    public class CameraMonoEntity : MonoEntity
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