using UnityEngine;

namespace _Application.Sources.MonoViews
{
    public interface IEnterPoint
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}