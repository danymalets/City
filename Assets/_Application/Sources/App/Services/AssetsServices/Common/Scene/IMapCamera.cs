using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Scene
{
    public interface IMapCamera
    {
        Vector2 Position { set; }
        float EulerAngleY { set; }
    }
}