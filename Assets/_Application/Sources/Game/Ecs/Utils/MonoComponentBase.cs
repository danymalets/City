using Leopotam.Ecs;
using UnityEngine;

namespace Sources.Game.Ecs.Utils
{
    public abstract class MonoComponentBase : MonoBehaviour
    {
        public abstract void Setup(EcsEntity entity);
    }
}