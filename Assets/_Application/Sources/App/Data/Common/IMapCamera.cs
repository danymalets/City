using UnityEngine;

namespace Sources.App.Data.Common
{
    public interface IMapCamera
    {
        Vector2 Position { set; }
        float EulerAngleY { set; }
    }
}