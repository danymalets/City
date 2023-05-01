using System.Collections;
using Sources.App.Data.Common;
using Sources.CommonServices.GizmosServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.App.Core.Ecs
{
    public class TestNav : MonoBehaviour
    {
        [SerializeField]
        private Transform _source;

        [SerializeField]
        private Transform _target;

        private GizmosContext _gizmosContext;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1);
            _gizmosContext = DiContainer.Resolve<IGizmosService>().CreateContext();

            NavigationService navigationService = new();
            navigationService.Initialize();

            this.RunEachSeconds(3f, () =>
            {
                if (navigationService.TryGetPath(_source.position, _target.position,
                        out NavMeshPath navPath))
                {
                    _gizmosContext.ClearAll();

                    var path = navPath.corners;

                    Color color = Color.green;

                    if (navPath.status == NavMeshPathStatus.PathInvalid)
                        color = Color.red;
                    else if (navPath.status == NavMeshPathStatus.PathPartial)
                    {
                        color = Color.blue;
                    }

                    Debug.Log($"path {path.Length} {navPath.status}");

                    for (int i = 0; i < path.Length - 1; i++)
                    {
                        _gizmosContext.DrawLine(path[i], path[i + 1], color);
                    }
                }
                else
                {
                    Debug.Log($"not ok");
                }
            }, false);
        }
    }
}