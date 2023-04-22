using System;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.App.Data.Common
{
    public class NavigationService : IInitializable
    {
        private int _npcAgentId;

        public void Initialize()
        {
            _npcAgentId = GetNavMeshAgentID("Player");
        }

        public bool TryGetPath(Vector3 source, Vector3 target, out Vector3[] path)
        {
            NavMeshPath navPath = new();
            if (NavMesh.CalculatePath(source, target,NavMesh.AllAreas, navPath))
            {
                path = navPath.corners;
                return true;
            }
            else
            {
                path = null;
                return false;
            }
        }
        
        private int GetNavMeshAgentID(string name)
        {
            for (int i = 0; i < NavMesh.GetSettingsCount(); i++)
            {
                NavMeshBuildSettings settings = NavMesh.GetSettingsByIndex(index: i);
                if (name == NavMesh.GetSettingsNameFromID(agentTypeID: settings.agentTypeID))
                {
                    return settings.agentTypeID;
                }
            }
            throw new ArgumentException($"NavMesh agent name \"{name}\" not found");
        }
    }
}