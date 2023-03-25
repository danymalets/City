using Scellecs.Morpeh;
using Sources.Game.Ecs.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Game.Ecs.DefaultComponents.Monos
{
    public abstract class SafeColliderBase : MonoBehaviour, IEntityAccess
    {
        public abstract bool IsTrigger { get; set; }
        public abstract Bounds Bounds { get; }
        
        public int Layer
        {
            get => gameObject.layer;
            set => gameObject.layer = value;
        }

        public Entity Entity { get; set; }
    }
}