using System.Collections.Generic;
using _Application.Sources.Utils.CommonUtils.Data;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Monos
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