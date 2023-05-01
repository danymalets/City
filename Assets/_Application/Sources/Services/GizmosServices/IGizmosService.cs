using Sources.Utils.Di;

namespace Sources.Services.GizmosServices
{
    public interface IGizmosService : IService
    {
        public GizmosContext CreateContext();
    }
}