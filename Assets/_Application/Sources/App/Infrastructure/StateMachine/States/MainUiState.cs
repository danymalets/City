using Sources.App.Data.Constants;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Services.AssetsServices.IdleCarSpawns;
using Sources.App.Ui.Screens.Level;
using Sources.Services.SceneLoaderServices;
using Sources.Services.UiServices.System;
using Sources.Utils.Di;

namespace Sources.App.Infrastructure.StateMachine.States
{
    public class MainUiState : GameState
    {
        private MainScreen _mainScreen;
        private IUiCloseService _uiCloseService;

        public MainUiState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            _mainScreen = DiContainer.Resolve<IUiService>().Get<MainScreen>();
            _uiCloseService = DiContainer.Resolve<IUiCloseService>();
            ISceneLoaderService sceneLoader = DiContainer.Resolve<ISceneLoaderService>();

            _mainScreen.Open();
            
            sceneLoader.LoadScene<EmptySceneContext>(Consts.EmptySceneName, _ =>
            {
                _mainScreen.PlayClicked += OnPlayClicked;
            });
        }

        private void OnPlayClicked()
        {
            _stateMachine.Enter<LoadLevelState>();
        }
        
        protected override void OnExit()
        {
            _mainScreen.PlayClicked -= OnPlayClicked;

            _uiCloseService.CloseAll();
            _mainScreen = null;
            _uiCloseService = null;
        }
    }
}