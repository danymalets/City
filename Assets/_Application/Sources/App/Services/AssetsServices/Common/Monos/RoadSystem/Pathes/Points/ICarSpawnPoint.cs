using Sources.App.Services.AssetsServices.Common.Monos.Cars;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points
{
    public interface ICarSpawnPoint
    {
        CarType CarType { get; }
        CarColorType CarColor { get; }
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}