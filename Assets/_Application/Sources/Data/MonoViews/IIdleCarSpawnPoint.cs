using Scellecs.Morpeh;
using UnityEngine;

namespace Sources.Data.MonoViews
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