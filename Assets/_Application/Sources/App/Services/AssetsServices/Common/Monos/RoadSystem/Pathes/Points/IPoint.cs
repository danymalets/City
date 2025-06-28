using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points
{
    public interface IPoint
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
        Vector3 Forward { get; }
        Vector3 Up { get; }
    }
}