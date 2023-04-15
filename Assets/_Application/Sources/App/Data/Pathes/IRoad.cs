using System.Collections.Generic;
using UnityEngine;

namespace _Application.Sources.App.Data.Pathes
{
    public interface IRoad
    {
        bool IsSpawnPoint { get; }
        IEnumerable<IRoadLane> RoadLanes { get; }
        public CrossroadsSideData GetSideData(Vector3 crossroadsPosition);
        public IRoadLane[] GetLanesByDistanceTo(Vector3 position);
    }
}