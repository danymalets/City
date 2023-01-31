using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components.Views.CarCollider;
using Sources.Game.Ecs.Components.Views.CarForwardTriggers;
using Sources.Game.Ecs.Utils;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarBorder
{
    public class EntityBorders : MonoBox, IEntityBorders
    {
        [Button("SET AUTO BORDERS", ButtonSizes.Large)]
        private void SetAutoBorders()
        {
            IEnumerable<Bounds> allBounds = GetComponentsInChildren<EntityCollider>().Select(c => c.Collider.bounds);

            Bounds bounds = DBounds.CombineBounds(allBounds);

            bounds.min = bounds.min.WithY(0);
            
            _boxCollider.center = bounds.center;
            _boxCollider.size = bounds.size;
        }
    }
}