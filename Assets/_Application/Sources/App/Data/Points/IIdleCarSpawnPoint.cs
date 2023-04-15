using Scellecs.Morpeh;
using Sources.App.Data.Cars;
using UnityEngine;

namespace Sources.App.Data.Points
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