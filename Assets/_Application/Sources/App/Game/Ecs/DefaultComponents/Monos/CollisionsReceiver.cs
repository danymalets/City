using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.Game.Ecs.Components.Collections;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Game.Ecs.DefaultComponents.Monos
{
    public class CollisionsReceiver : MonoBehaviour
    {
        public Entity Entity { private get; set; }

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