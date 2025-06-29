using Sources.App.Services.AssetsServices.Common.Cars.CarsData;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.IdleCarSpawns
{
    public interface ICarSpawnPoint
    {
        CarType CarType { get; }
        CarColorType CarColor { get; }
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}