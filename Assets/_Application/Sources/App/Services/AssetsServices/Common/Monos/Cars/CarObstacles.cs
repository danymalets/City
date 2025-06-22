using System.Collections.Generic;
using System.Linq;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Utils;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.App.Services.AssetsServices.Common.Monos.Cars
{
    public class CarObstacles : MonoBehaviour
    {
        private const float ForwardDistance = 0.3f;

        [SerializeField]
        private NavMeshObstacle _navMeshObstacle;

        public void SetupBounds(SafeColliderBase[] colliders)
        {
            IEnumerable<Bounds> allBounds = colliders.Select(c => c.Bounds);

            Bounds bounds = BoundsUtils.CombineBounds(allBounds);

            bounds.min = bounds.min.WithY(0);

            _navMeshObstacle.center = bounds.center + Vector3.forward * ForwardDistance / 2;
            _navMeshObstacle.size = bounds.size + Vector3.forward * ForwardDistance;
        }
    }
}