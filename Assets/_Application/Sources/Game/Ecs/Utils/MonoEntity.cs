using Scellecs.Morpeh;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services.Pool;
using UnityEngine;

namespace Sources.Game.Ecs.Utils
{
    public abstract class MonoEntity : RespawnableBehaviour
    {
        public Entity Entity { get; private set; }

        public void Setup(Entity entity)
        {
            Entity = entity;
            entity.Set(new MonoEntityAccess{MonoEntity = this});
            OnSetup();
        }

        protected abstract void OnSetup();
        
        public void Cleanup()
        {
            Entity = null;
            OnCleanup();
        }

        protected abstract void OnCleanup();
    }
}