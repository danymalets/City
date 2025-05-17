using Sources.Services.LogServices;
using Sources.Utils.CommonUtils.Utils;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.App.Core.Services.Navigation
{
    public class NavigationService : INavigationService, IInitializable
    {
        private int _playerAgentId;
        private int _carAgentId;
        private ILogService _logService;

        public void Initialize()
        {
            _playerAgentId = NavMeshUtility.GetNavMeshAgentID("Player");
            _carAgentId = NavMeshUtility.GetNavMeshAgentID("Car");
            _logService = DiContainer.Resolve<ILogService>();
        }

        public bool TryGetPlayerPath(Vector3 source, Vector3 target, out Vector3[] path)
        {
            return TryGetPath(_playerAgentId, source, target, 0.5f, 10f, out path);
        }

        public bool TryGetCarPath(Vector3 source, Vector3 target, out Vector3[] path)
        {
            return TryGetPath(_carAgentId, source, target, 0.5f, 0.5f, out path);
        }

        private bool TryGetPath(int agentId, Vector3 source, Vector3 target,
            float maxDistanceFromSource, float maxDistanceToTarget, out Vector3[] path)
        {
            return TryGetPathInternal(agentId, source, target, maxDistanceToTarget, out path);
        }

        private bool TryGetPathWithPerformance(int agentId, Vector3 source, Vector3 target,
            float maxDistanceToTarget, out Vector3[] path)
        {
            bool result = false;
            Vector3[] pathInternal = null;
            PerformanceUtils.Execute(() => { result = TryGetPathInternal(agentId, source, target, maxDistanceToTarget, out pathInternal); },
                ticks => { _logService.Log($"Path finder solve in {ticks / 1000:F}"); });
            path = pathInternal;
            return result;
        }

        private bool TryGetPathInternal(int agentId, Vector3 source, Vector3 target,
            float maxDistanceToTarget, out Vector3[] path)
        {
            NavMeshPath navPath = new();

            NavMeshQueryFilter navMeshQueryFilter = new()
            {
                agentTypeID = agentId,
                areaMask = NavMesh.AllAreas
            };

            if (NavMesh.CalculatePath(source, target, navMeshQueryFilter, navPath)
                && Vector3Utils.SqrDistance(target, navPath.corners[^1]) < MathUtils.Sqr(maxDistanceToTarget))
            {
                path = navPath.corners;
                return true;
            }
            else
            {
                path = default;
                return false;
            }
        }
    }
}