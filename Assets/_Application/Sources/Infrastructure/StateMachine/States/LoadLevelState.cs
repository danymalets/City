using Sources.Game;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.SceneLoader;
using Sources.Infrastructure.Services.User;
using Sources.Infrastructure.StateMachine.Machine;
using Sources.Infrastructure.StateMachine.StateBase;
using Sources.UI.Screens;
using Sources.UI.System;

namespace Sources.Infrastructure.StateMachine.States
{
    public class LoadLevelState : GameState
    {
        private ISceneLoaderService _sceneLoader;
        private IBalanceService _balanceService;
        private LoadingScreen _loadingScreen;

        public LoadLevelState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            _loadingScreen = DiContainer.Resolve<IUiService>().Get<LoadingScreen>();
            
            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();
            _balanceService = DiContainer.Resolve<IBalanceService>();

            int level = DiContainer.Resolve<IUserAccessService>()
                .User.Progress.CurrentLevel;

            string cityScene = DiContainer.Resolve<IAssetsService>().CitySceneName;

            //int realLevel = GetRealLevel(level, _balanceService.LevelsCount);

            //LevelBalance balance = _balanceService.GetLevelBalance(realLevel);
            
            _loadingScreen.Open();

            _sceneLoader.LoadScene<LevelContextService>(cityScene, levelContext => 
                EnterLevelState(new LevelData(level, levelContext)));
        }

        private void EnterLevelState(LevelData levelData)
        {
            _loadingScreen.Close();
            _stateMachine.Enter<LevelState, LevelData>(levelData);
        }

        private int GetRealLevel(int level, int levelsCount) => 
            (level - 1) % levelsCount + 1;
    }
}