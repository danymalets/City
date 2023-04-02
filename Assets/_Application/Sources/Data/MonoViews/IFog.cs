using UnityEngine;

namespace Sources.Data.MonoViews
{
    public interface IFog
    {
        Vector3 Position { get; set; }
        void SetRadius(float radius);
    }
}