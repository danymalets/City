using UnityEngine;

namespace Sources.Infrastructure.Services.Gizmoses
{
    public interface IGizmosService : IService
    {
        public GizmosContext CreateContext();
    }
}