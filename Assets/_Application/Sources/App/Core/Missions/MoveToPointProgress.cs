using Sources.ProjectServices.UserService;
using UnityEngine;

namespace Sources.App.Core.Missions
{
    public class MoveToPointProgress : SubMissionProgress
    {
        public Vector3 StartPosition { get; set; }
    }
}