using Sources.App.Data.Constants;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Services.AssetsServices.IdleCarSpawns;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.MainScreens;
using Sources.Services.SceneLoaderServices;
using Sources.Services.UiServices.System;
using Sources.Utils.Di;

namespace Sources.App.Infrastructure.StateMachine.States
{
    public class MainUiState : GameState
    {
        private MainScreenController _mainScreenController;
        private IUiCloseService _uiCloseService;
        
        public MainUiState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            _mainScreenController = DiContainer.Resolve<IUiControllersService>().Get<MainScreenController>();
            _uiCloseService = DiContainer.Resolve<IUiCloseService>();
            ISceneLoaderService sceneLoader = DiContainer.Resolve<ISceneLoaderService>();

            _mainScreenController.Open();
            
            sceneLoader.LoadScene<EmptySceneContext>(Consts.EmptySceneName, _ =>
            {
                _mainScreenController.PlayClicked += OnPlayClicked;
            });
        }

        private void OnPlayClicked()
        {
            _stateMachine.Enter<LoadLevelState>();
        }
        
        protected override void OnExit()
        {
            _mainScreenController.PlayClicked -= OnPlayClicked;

            _uiCloseService.CloseAll();
            _mainScreenController = null;
            _uiCloseService = null;
        }
    }
}