using System.Collections.Generic;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Pathes
{
    public interface IRoad
    {
        bool IsSpawnPoint { get; }
        IEnumerable<IRoadLane> RoadLanes { get; }
        public CrossroadsSideData GetSideData(Vector3 crossroadsPosition);
        public IRoadLane[] GetLanesByDistanceTo(Vector3 position);
    }
}