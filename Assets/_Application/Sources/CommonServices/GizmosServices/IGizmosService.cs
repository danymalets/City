using _Application.Sources.Utils.Di;

namespace _Application.Sources.CommonServices.GizmosServices
{
    public interface IGizmosService : IService
    {
        public GizmosContext CreateContext();
    }
}