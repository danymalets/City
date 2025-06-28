using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Monos.Cars
{
    public interface IEnterPoint
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
        CarSideType SideType { get; }
    }
}