using _Application.Sources.App.Data.Points;
using UnityEngine;

namespace _Application.Sources.App.Data.Pathes
{
    public interface IRoadLaneCheckpoint
    {
        Vector3 Position { get; }
        Point RelatedPoint { get; set; }
    }
}