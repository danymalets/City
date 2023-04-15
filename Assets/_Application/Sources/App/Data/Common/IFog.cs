using UnityEngine;

namespace Sources.Data.Common
{
    public interface IFog
    {
        Vector3 Position { get; set; }
        void SetRadius(float radius);
    }
}