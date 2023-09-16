using Sources.App.Core.Services.Input;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Input
{
    public class GameplayInputResetSystem : DUpdateSystem
    {
        private readonly IGameplayInputService _gameplayInputService;

        public GameplayInputResetSystem()
        {
            _gameplayInputService = DiContainer.Resolve<IGameplayInputService>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            _gameplayInputService.Reset();
        }
    }
}