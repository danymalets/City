using Sources.Data;
using Sources.Data.Live;
using Sources.Game;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.SceneLoader;
using Sources.Infrastructure.StateMachine.Machine;
using Sources.Infrastructure.StateMachine.StateBase;
using Sources.UI.Screens;
using Sources.UI.System;

namespace Sources.Infrastructure.StateMachine.States
{
    public class LoadLevelStateBase : GameState
    {
        private ISceneLoaderService _sceneLoader;
        private IBalanceService _balanceService;
        private LoadingScreen _loadingScreen;
        
        private LiveInt _currentLevel;

        public LoadLevelStateBase(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            _currentLevel = Progress.CurrentLevel;

            _loadingScreen = UiSystem.Get<LoadingScreen>();
            
            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();
            _balanceService = DiContainer.Resolve<IBalanceService>();
            
            int level = _currentLevel.Value;

            int realLevel = GetRealLevel(level, _balanceService.LevelsCount);

            LevelBalance balance = _balanceService.GetLevelBalance(realLevel);
            
            _loadingScreen.Open();

            _sceneLoader.LoadScene(balance.LevelSceneType.GetSceneName(), () => 
                EnterLevelState(new LevelData(level, balance)));
        }

        private void EnterLevelState(LevelData levelData)
        {
            _loadingScreen.Close();
            _stateMachine.Enter<LevelStateBase, LevelData>(levelData);
        }

        private int GetRealLevel(int level, int levelsCount) => 
            (level - 1) % levelsCount + 1;
    }
}