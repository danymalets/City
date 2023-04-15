using System.Collections.Generic;
using System.Linq;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.Utils.CommonUtils.Extensions;
using _Application.Sources.Utils.CommonUtils.Libs;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using UnityEngine;

namespace Sources.Monos.Cars
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