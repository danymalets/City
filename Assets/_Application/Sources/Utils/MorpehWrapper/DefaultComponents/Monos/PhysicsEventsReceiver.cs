using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.CommonUtils.Data;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    public class PhysicsEventsReceiver : MonoBehaviour, IEntityAccess
    {
        public Entity Entity { get; set; }

        private void OnCollisionEnter(Collision collision)
        {
            if (Entity.TryGet(out Collisions collisions) &&
                collision.transform.TryGetComponent(out IEntityAccess another))
            {
                collisions.List.Add(new CollisionData(
                    another.Entity, 
                    collision.impulse.sqrMagnitude));
            }
        }
    }
}