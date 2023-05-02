using UnityEngine;

namespace Sources.App.Data.Cars
{
    public interface IEnterPoint
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
        EnterPointSideType SideType { get; }
    }
}