using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Scene
{
    public interface IFog
    {
        Vector3 Position { get; set; }
        void SetRadius(float radius);
    }
}