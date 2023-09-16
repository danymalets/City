using Sources.Utils.Di;

namespace Sources.App.Core.Services.Input
{
    public interface IGameplayInputAccessService : IService
    {
        public GameplayInputData GameplayInputData { get; }
    }
}