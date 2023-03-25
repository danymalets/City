using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Game.Ecs.DefaultComponents.Monos;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Components.Views
{
    [RequireComponent(typeof(SafeBoxCollider))]
    public class CarBorders : MonoBehaviour, ICarBorders
    {
        [SerializeField]
        private SafeBoxCollider _safeBoxCollider;

        public SafeBoxCollider SafeBoxCollider => _safeBoxCollider;

        private void OnValidate()
        {
            _safeBoxCollider = GetComponent<SafeBoxCollider>();
        }

        public void SetupBounds(SafeColliderBase[] colliders)
        {
            IEnumerable<Bounds> allBounds = colliders.Select(c => c.Bounds);

            Bounds bounds = DBounds.CombineBounds(allBounds);

            bounds.min = bounds.min.WithY(0);
            
            _safeBoxCollider.Center = bounds.center;
            _safeBoxCollider.Size = bounds.size;
        }
    }
}