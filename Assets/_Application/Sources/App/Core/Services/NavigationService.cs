using System;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.App.Data.Common
{
    public class NavigationService : IService, IInitializable
    {
        private int _playerAgentId;
        private int _carAgentId;

        public void Initialize()
        {
            _playerAgentId = NavMeshUtility.GetNavMeshAgentID("Player");
            _carAgentId = NavMeshUtility.GetNavMeshAgentID("Car");
            Debug.Log($"_npcAgentId{_playerAgentId} ");
        }

        public bool TryGetPlayerPath(Vector3 source, Vector3 target, out Vector3[] path) =>
            TryGetPath(_playerAgentId, source, target, out path);
        
        public bool TryGetCarPath(Vector3 source, Vector3 target, out Vector3[] path) =>
            TryGetPath(_carAgentId, source, target, out path);

        private bool TryGetPathWithPerformance(int agentId, Vector3 source, Vector3 target, out Vector3[] path)
        {
            bool result = false;
            Vector3[] pathInternal = null;
            DPerformance.Execute(() =>
            {
                result = TryGetPath(agentId, source, target, out pathInternal);
            }, ticks =>
            {
                Debug.Log($"Path finder solve in {ticks/1000:F}");
            });
            path = pathInternal;
            return result;
        }

        private bool TryGetPath(int agentId, Vector3 source, Vector3 target, out Vector3[] path)
        {
            NavMeshPath navPath = new();
            
            NavMeshQueryFilter navMeshQueryFilter = new ()
            {
                agentTypeID = agentId,
                areaMask = NavMesh.AllAreas
            };
            
            if (NavMesh.CalculatePath(source, target, navMeshQueryFilter, navPath))
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