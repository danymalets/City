using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Infrastructure.StateMachine.States.LevelStates;
using Sources.App.Services.AssetsServices;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.CurrencyScreens;
using Sources.App.Ui.Screens.LoadingScreens;
using Sources.App.Ui.Screens.MainScreens;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.SceneLoaderServices;
using Sources.Utils.Di;

namespace Sources.App.Infrastructure.StateMachine.States.MainUiStates
{
    public class MainUiState : GameState
    {
        private MainScreenController _mainScreenController;
        private IUiCloseService _uiCloseService;
        private CurrencyScreenController _currencyScreenController;
        private ISceneLoaderService _sceneLoader;
        private Assets _assets;
        private LoadingScreenController _loadingScreen;
        private CoroutineContext _coroutineContext;

        public MainUiState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            IUiControllersService uiControllers = DiContainer.Resolve<IUiControllersService>();
            
            _mainScreenController = uiControllers.Get<MainScreenController>();
            _loadingScreen = uiControllers.Get<LoadingScreenController>();
            _currencyScreenController = uiControllers.Get<CurrencyScreenController>();

            _uiCloseService = DiContainer.Resolve<IUiCloseService>();

            _coroutineContext = new CoroutineContext();

            _mainScreenController.Open();
            _currencyScreenController.Open();
            
            _assets = DiContainer.Resolve<Assets>();
            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();

            _sceneLoader.LoadEmptyScene(() =>
            {
            });
            _mainScreenController.PlayButtonClicked += OnPlayButtonClicked;

            RunScreenLoading();
        }

        private void RunScreenLoading()
        {
            _loadingScreen.Open();
            _coroutineContext.ChangeValue(0, 1, 1, value =>
            {
                _loadingScreen.SetProgress(value);
            }, () =>
            {
                _coroutineContext.RunNextFrame(() => _loadingScreen.Close());
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
            _assets = null;
            _sceneLoader = null;
        }
    }
}