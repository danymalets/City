using Sources.Di;

namespace Sources.Services.Gizmoses
{
    public interface IGizmosService : IService
    {
        public GizmosContext CreateContext();
    }
}