using UnityEngine;

namespace Sources.App.Services.AssetsServices.IdleCarSpawns.Common
{
    public interface IFog
    {
        Vector3 Position { get; set; }
        void SetRadius(float radius);
    }
}