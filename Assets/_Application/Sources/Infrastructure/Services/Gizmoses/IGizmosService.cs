using UnityEngine;

namespace Sources.Infrastructure.Services.Gizmoses
{
    public interface IGizmosService : IService
    {
        void DrawSphere(Vector3 center, float radius, Color color);
    }
}