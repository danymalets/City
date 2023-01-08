using Scellecs.Morpeh;
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
            OnSetup();
        }

        protected abstract void OnSetup();
    }
}