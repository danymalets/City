using Sources.App.Core.Services.Input;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Input
{
    public class GameplayInputUpdateSystem : DUpdateSystem
    {
        private readonly IGameplayInputService _gameplayInputService;

        public GameplayInputUpdateSystem()
        {
            _gameplayInputService = DiContainer.Resolve<IGameplayInputService>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            _gameplayInputService.Update();
        }
    }
}