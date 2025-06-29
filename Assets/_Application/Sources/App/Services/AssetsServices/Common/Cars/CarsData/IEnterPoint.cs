using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Cars.CarsData
{
    public interface IEnterPoint
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
        CarSideType SideType { get; }
    }
}