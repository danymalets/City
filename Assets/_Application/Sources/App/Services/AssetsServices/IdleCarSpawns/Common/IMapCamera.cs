using UnityEngine;

namespace Sources.App.Services.AssetsServices.IdleCarSpawns.Common
{
    public interface IMapCamera
    {
        Vector2 Position { set; }
        float EulerAngleY { set; }
    }
}