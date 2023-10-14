using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Infrastructure.StateMachine.States.LevelStates;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.CurrencyScreens;
using Sources.App.Ui.Screens.MainScreens;
using Sources.Services.SceneLoaderServices;
using Sources.Utils.Di;

namespace Sources.App.Infrastructure.StateMachine.States.MainUiStates
{
    public class MainUiState : GameState
    {
        private MainScreenController _mainScreenController;
        private IUiCloseService _uiCloseService;
        private CurrencyScreenController _currencyScreenController;

        public MainUiState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            IUiControllersService uiControllers = DiContainer.Resolve<IUiControllersService>();
            
            _mainScreenController = uiControllers.Get<MainScreenController>();
            _currencyScreenController = uiControllers.Get<CurrencyScreenController>();

            _uiCloseService = DiContainer.Resolve<IUiCloseService>();
            ISceneLoaderService sceneLoader = DiContainer.Resolve<ISceneLoaderService>();

            _mainScreenController.Open();
            _currencyScreenController.Open();
            
            sceneLoader.LoadEmptyScene(() =>
            {
                _mainScreenController.PlayButtonClicked += OnPlayButtonClicked;
            });
        }

        private void OnPlayButtonClicked()
        {
            _stateMachine.Enter<LevelState>();
        }
        
        protected override void OnExit()
        {
            _mainScreenController.PlayButtonClicked -= OnPlayButtonClicked;

            _uiCloseService.CloseAll();
            _mainScreenController = null;
            _uiCloseService = null;
        }
    }
}