using _Application.Sources.App.Data.Cars;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Application.Sources.App.Data.Points
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