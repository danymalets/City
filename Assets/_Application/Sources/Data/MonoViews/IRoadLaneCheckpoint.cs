using UnityEngine;

namespace Sources.Data.MonoViews
{
    public interface IRoadLaneCheckpoint
    {
        Vector3 Position { get; }
        Point RelatedPoint { get; set; }
    }
}