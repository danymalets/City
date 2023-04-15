using UnityEngine;

namespace _Application.Sources.App.Data.Cars
{
    public interface IEnterPoint
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}