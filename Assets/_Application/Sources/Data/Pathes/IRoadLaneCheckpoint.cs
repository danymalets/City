using Sources.Data.Points;
using UnityEngine;

namespace Sources.Data.Pathes
{
    public interface IRoadLaneCheckpoint
    {
        Vector3 Position { get; }
        Point RelatedPoint { get; set; }
    }
}