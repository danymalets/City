using System;
using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarCollider
{
    public class EntityCollider : MonoBehaviour
    {
        [SerializeField]
        private Collider _collider;

        public Collider Collider => _collider;

        public void Setup(Entity entity)
        {
        }
        //
        // private void OnCollisionEnter(Collision collision)
        // {
        //     GameObject rootObj = collision.transform.root.gameObject;
        //     if (rootObj.TryGetComponent(out MonoEntity monoEntity))
        //     {
        //         _collisions.Add(new CollisionData(monoEntity.Entity, collision.impulse.sqrMagnitude));
        //     }
        // }

        private void OnValidate()
        {
            _collider = GetComponent<Collider>();
        }

        public void Cleanup()
        {
        }
    }
}