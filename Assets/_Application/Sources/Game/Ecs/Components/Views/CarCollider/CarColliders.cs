using System;
using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh.Providers;
using Sources.Game.Constants;
using Sources.Game.Ecs.Utils;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarCollider
{
    public class CarColliders : MonoBehaviour, ICarColliders
    {
        [SerializeField]
        private Collider[] _colliders;

        public Collider[] Colliders => _colliders;

        private void OnValidate()
        {
            if (_colliders != null)
            {
                foreach (Collider collider in _colliders)
                {
                    if (collider != null)
                    {
                        collider.isTrigger = false;
                        collider.gameObject.layer = Layers.Car;
                    }
                }
            }
        }
    }
}