using System;
using System.Collections;
using Sources.CommonServices.GizmosServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Data.Common
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

            this.RunEachSeconds(0.5f, () =>
            {
                NavigationService navigationService = new ();
                navigationService.Initialize();
                _gizmosContext.ClearAll();
                if (navigationService.TryGetPath(_source.position, _target.position,
                        out Vector3[] path))
                {
                    for (int i = 0; i < path.Length-1; i++)
                    {
                        _gizmosContext.DrawLine(path[i], path[i+1], Color.red);
                    }
                }
                else
                {
                    Debug.Log($"not found");
                }
            }, false);
        }
    }
}