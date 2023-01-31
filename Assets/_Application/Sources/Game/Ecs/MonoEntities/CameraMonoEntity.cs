using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.Camera;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.MonoEntities
{
    [RequireComponent(typeof(TransformComponent))]
    [RequireComponent(typeof(CameraData))]
    public class CameraMonoEntity : MonoEntity
    {
        [SerializeField]
        private TransformComponent _transform;

        [SerializeField]
        private CameraData _cameraData;
        
        private void OnValidate()
        {
            _transform = GetComponent<TransformComponent>();
            _cameraData = GetComponent<CameraData>();
        }

        protected override void OnSetup()
        {
            Entity.SetMono<ITransform>(_transform);
            Entity.SetMono<ICameraData>(_cameraData);
        }

        protected override void OnCleanup()
        {
        }
    }
}