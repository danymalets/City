using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes
{
    public interface IRoadLaneCheckpoint
    {
        Vector3 Position { get; }
        PathPoint RelatedPoint { get; set; }
    }
}