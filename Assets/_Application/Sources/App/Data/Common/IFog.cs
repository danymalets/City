using UnityEngine;

namespace _Application.Sources.App.Data.Common
{
    public interface IFog
    {
        Vector3 Position { get; set; }
        void SetRadius(float radius);
    }
}