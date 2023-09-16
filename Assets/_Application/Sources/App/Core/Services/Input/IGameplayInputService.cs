using Sources.Utils.Di;

namespace Sources.App.Core.Services.Input
{
    public interface IGameplayInputService : IService
    {
        void Update();
        void Reset();
    }
}