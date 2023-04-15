using Sources.Utils.Di;

namespace Sources.CommonServices.GizmosServices
{
    public interface IGizmosService : IService
    {
        public GizmosContext CreateContext();
    }
}