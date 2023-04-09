using UnityEngine;

namespace Sources.Data.Pathes
{
    public interface ICrossroads
    {
        IRoad Forward { get; }
        IRoad Right { get; }
        IRoad Back { get; }
        IRoad Left { get; }
        IRoad ForwardRelated { get; }
        IRoad RightRelated { get; }
        IRoad BackRelated { get; }
        IRoad LeftRelated { get; }
        IRoad[] GetAllRoads();
        IRoad[] GetAllRelatedRoads();
        Vector3 Position { get; }
    }
}