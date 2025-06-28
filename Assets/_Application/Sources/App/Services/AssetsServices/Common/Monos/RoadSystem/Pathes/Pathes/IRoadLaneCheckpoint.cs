using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Pathes
{
    public interface IRoadLaneCheckpoint
    {
        Vector3 Position { get; }
        Point RelatedPoint { get; set; }
    }
}