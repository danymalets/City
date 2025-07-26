using Cysharp.Threading.Tasks;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Infrastructure.StateMachine.States.LevelStates;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.GameReloadServices;
using Sources.App.Services.GameRunnerServices;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.CurrencyScreens;
using Sources.App.Ui.Screens.LoadingScreens;
using Sources.App.Ui.Screens.MainScreens;
using Sources.Services.AdsServices;
using Sources.Services.SceneLoaderServices;
using Sources.Services.UpdateLoopServices;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.App.Infrastructure.StateMachine.States.MainUiStates
{
    public class MainUiState : GameState<bool>
    {
        private MainScreenController _mainScreenController;
        private IUiCloseService _uiCloseService;
        private CurrencyScreenController _currencyScreenController;
        private ISceneLoaderService _sceneLoader;
        private Assets _assets;
        private LoadingScreenController _loadingScreen;
        private IUpdateLoopService _updateLoopService;
        private IAdsService _adsService;
        private IDiBuilder _diBuilder;
        private MatchRunnerService _matchRunnerService;
        private GameReloadService _gameReloadService;

        public MainUiState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override async void OnEnter(bool isFirstEnter)
        {
            IUiControllersService uiControllers = DiContainer.Resolve<IUiControllersService>();


            _diBuilder = DiBuilder.Create();
            
            _matchRunnerService = new MatchRunnerService();
            _diBuilder.Register<IGameRunnerService>(_matchRunnerService);
            
            _gameReloadService = new GameReloadService();
            _diBuilder.Register<IGameReloadService>(_gameReloadService);

            _updateLoopService = DiContainer.Resolve<IUpdateLoopService>();

            _mainScreenController = uiControllers.Get<MainScreenController>();
            _loadingScreen = uiControllers.Get<LoadingScreenController>();
            _currencyScreenController = uiControllers.Get<CurrencyScreenController>();

            _uiCloseService = DiContainer.Resolve<IUiCloseService>();
            _adsService = DiContainer.Resolve<IAdsService>();

            _mainScreenController.Open();
            _currencyScreenController.Open();
            
            _assets = DiContainer.Resolve<Assets>();
            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();

            RunScreenLoading().Forget();

            await _sceneLoader.LoadEmptyScene();
            var playerRenderSceneContext = await _sceneLoader.LoadScene<PlayerRenderSceneContext>(_assets.ScenesAssets.PlayerRenderSceneName, LoadSceneMode.Additive);
            
            Transform player = playerRenderSceneContext.Player;

            _matchRunnerService.RunGameRequested += MatchRunnerRunMatchRequested;
            _gameReloadService.ReloadGameRequested += GameReloader_ReloadGameRequested;
        }

        private async UniTask RunScreenLoading()
        {
            _loadingScreen.Open();

            await _updateLoopService.ChangeValue(0, 1, 1, value =>
                _loadingScreen.SetProgress(value));

            await UniTask.NextFrame();

            _loadingScreen.Close();
            
            await _adsService.ShowInterstitial();
        }

        private void MatchRunnerRunMatchRequested(RunMatchSettings runMatchSettings)
        {
            _stateMachine.Enter<LevelState, RunMatchSettings>(runMatchSettings);
        }
        
        private void GameReloader_ReloadGameRequested()
        {
            _stateMachine.Enter<MainUiState, bool>(false);
        }
        
        protected override void OnExit()
        {            
            _matchRunnerService.RunGameRequested -= MatchRunnerRunMatchRequested;
            _diBuilder.Dispose();
            
            _sceneLoader.UnloadScene(_assets.ScenesAssets.PlayerRenderSceneName);           
            
            _uiCloseService.CloseAll();
            _mainScreenController = null;
            _uiCloseService = null;
            _assets = null;
            _sceneLoader = null;
        }
    }
}