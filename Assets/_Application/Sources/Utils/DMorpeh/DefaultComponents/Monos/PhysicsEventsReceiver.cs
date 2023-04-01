using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.Data;
using Sources.Utils.DMorpeh.DefaultComponents.Views;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using UnityEngine;

namespace Sources.Utils.DMorpeh.DefaultComponents.Monos
{
    public class PhysicsEventsReceiver : MonoBehaviour, IEntityAccess
    {
        public Entity Entity { get; set; }

        private void OnCollisionEnter(Collision collision)
        {
            if (Entity == null)
                return;
            
            List<CollisionData> collisions = 
                (Entity.TryGet(out Collisions cc) ? cc : 
                    Entity.SetAndGet(new Collisions{List = new List<CollisionData>()})).List;
            
            if (collision.transform.TryGetComponent(out IEntityAccess another))
            {
                collisions.Add(new CollisionData(another.Entity, collision.impulse.sqrMagnitude));
            }
        }
    }
}