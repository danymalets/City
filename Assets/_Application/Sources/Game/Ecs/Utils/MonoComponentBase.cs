using Scellecs.Morpeh;
using UnityEngine;

namespace Sources.Game.Ecs.Utils
{
    public abstract class MonoComponentBase : MonoBehaviour
    {
        public abstract void Setup(Entity entity);
    }
}