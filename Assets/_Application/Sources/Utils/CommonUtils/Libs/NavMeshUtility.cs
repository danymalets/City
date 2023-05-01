using System;
using UnityEngine.AI;

namespace Sources.Utils.CommonUtils.Libs
{
    public static class NavMeshUtility
    {
        public static int GetNavMeshAgentID(string name)
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