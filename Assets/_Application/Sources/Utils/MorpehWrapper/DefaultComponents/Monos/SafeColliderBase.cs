using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    public abstract class SafeColliderBase : PhysicsEventsReceiver, IEntityAccess
    {
        public abstract bool IsTrigger { get; set; }
        public abstract Bounds Bounds { get; }
        
        public int Layer
        {
            get => gameObject.layer;
            set => gameObject.layer = value;
        }
        public abstract PhysicMaterial PhysicsMaterial { get; set; }
    }
}