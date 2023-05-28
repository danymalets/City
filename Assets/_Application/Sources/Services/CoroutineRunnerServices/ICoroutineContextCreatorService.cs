using Sources.Utils.Di;

namespace Sources.Services.CoroutineRunnerServices
{
    public interface ICoroutineContextCreatorService : IService
    {
        CoroutineContext CreateCoroutineContext();
    }
}