using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components.Views.CarCollider;
using Sources.Game.Ecs.Utils;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarBorder
{
    public class CarBorders : MonoBehaviour, ICarBorders
    {
        [SerializeField]
        private BoxCollider _boxCollider;

        private void OnValidate()
        {
            _boxCollider.isTrigger = true;
            // _boxCollider.gameObject.layer = Layers.CarBorders;
        }

        public Vector3 Center => 
            _boxCollider.center;

        public Vector3 HalfExtents =>
            _boxCollider.size / 2;

        [Button("SET AUTO BORDERS", ButtonSizes.Large)]
        private void SetAutoBorders()
        {
            IEnumerable<Bounds> allBounds = GetComponent<CarColliders>().Colliders.Select(c => c.bounds);
            
            Bounds bounds = DBounds.CombineBounds(allBounds);

            bounds.min = bounds.min.WithY(0);
            
            _boxCollider.center = bounds.center;
            _boxCollider.size = bounds.size;
        }
    }
}