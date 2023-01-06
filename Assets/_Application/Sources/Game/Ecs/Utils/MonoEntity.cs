using Scellecs.Morpeh;
using Sources.Infrastructure.Services.Pool;
using UnityEngine;

namespace Sources.Game.Ecs.Utils
{
    public class MonoEntity : RespawnableBehaviour
    {
        [SerializeField]
        private MonoComponentBase[] _viewComponents;

        public Entity Entity { get; private set; }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            _viewComponents = GetComponents<MonoComponentBase>();
        }
#endif

        public void Setup(Entity entity)
        {
            Entity = entity;
            
            foreach (MonoComponentBase viewComponent in _viewComponents)
            {
                viewComponent.Setup(entity);
            }
        }
    }
}