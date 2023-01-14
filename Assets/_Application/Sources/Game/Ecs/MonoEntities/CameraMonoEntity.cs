using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.MonoEntities
{
    [RequireComponent(typeof(TransformComponent))]
    public class CameraMonoEntity : MonoEntity
    {
        [SerializeField]
        private TransformComponent _transform;

        private void OnValidate()
        {
            _transform = GetComponent<TransformComponent>();
        }

        protected override void OnSetup()
        {
            Entity.SetMono<ITransform>(_transform);
        }
    }
}