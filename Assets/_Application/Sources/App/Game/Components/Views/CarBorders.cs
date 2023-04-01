using System.Collections.Generic;
using System.Linq;
using Sources.App.Game.Components.Monos;
using Sources.DMorpeh.DefaultComponents.Monos;
using Sources.Utils.Extensions;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.App.Game.Components.Views
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