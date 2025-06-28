using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points
{
    public interface ICameraPoint
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
        float FieldOfView { get; }
    }
}