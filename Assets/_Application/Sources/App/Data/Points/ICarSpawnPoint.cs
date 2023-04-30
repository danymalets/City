using Scellecs.Morpeh;
using Sources.App.Data.Cars;
using UnityEngine;

namespace Sources.App.Data.Points
{
    public interface ICarSpawnPoint
    {
        CarType CarType { get; }
        CarColorType CarColor { get; }
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}