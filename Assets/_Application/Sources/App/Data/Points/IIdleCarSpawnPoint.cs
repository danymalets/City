using Scellecs.Morpeh;
using Sources.Data.Cars;
using UnityEngine;

namespace Sources.Data.Points
{
    public interface IIdleCarSpawnPoint
    {
        CarType CarType { get; }
        CarColorType? CarColor { get; }
        Vector3 Position { get; }
        Quaternion Rotation { get; }
        Entity AliveCar { get; set; }
    }
}