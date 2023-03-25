using Sirenix.OdinInspector;
using Sources.Game.Ecs.DefaultComponents;
using Sources.Game.Ecs.DefaultComponents.Monos;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Game.Ecs.MonoEntities
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