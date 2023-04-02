using UnityEngine;

namespace Sources.Data.MonoViews
{
    public interface IEnterPoint
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}