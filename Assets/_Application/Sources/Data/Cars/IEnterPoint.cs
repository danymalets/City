using UnityEngine;

namespace Sources.Data.Cars
{
    public interface IEnterPoint
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}