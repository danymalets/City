using Scellecs.Morpeh;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Game.Ecs.DefaultComponents.Monos
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
        public abstract PhysicMaterial PhysicsMaterial { get; set; }
    }
}