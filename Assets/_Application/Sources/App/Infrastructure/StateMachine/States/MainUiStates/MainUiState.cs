using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Infrastructure.StateMachine.States.LevelStates;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.Monos.MonoEntities.Player;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.CurrencyScreens;
using Sources.App.Ui.Screens.LoadingScreens;
using Sources.App.Ui.Screens.MainScreens;
using Sources.Services.GameLoopServices;
using Sources.Services.SceneLoaderServices;
using Sources.Utils.Di;
using UnityEngine.SceneManagement;

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
        private IGameLoopService _gameLoopService;

        public MainUiState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override async void OnEnter()
        {
            IUiControllersService uiControllers = DiContainer.Resolve<IUiControllersService>();
            
            _gameLoopService = DiContainer.Resolve<IGameLoopService>();

            _mainScreenController = uiControllers.Get<MainScreenController>();
            _loadingScreen = uiControllers.Get<LoadingScreenController>();
            _currencyScreenController = uiControllers.Get<CurrencyScreenController>();

            _uiCloseService = DiContainer.Resolve<IUiCloseService>();

            _mainScreenController.Open();
            _currencyScreenController.Open();
            
            _assets = DiContainer.Resolve<Assets>();
            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();

            RunScreenLoading().Forget();

            await _sceneLoader.LoadEmptyScene();
            var playerRenderSceneContext = await _sceneLoader.LoadScene<PlayerRenderSceneContext>(_assets.PlayerRenderSceneName, LoadSceneMode.Additive);
            
            PlayerMonoEntity player = playerRenderSceneContext.Player;
            _mainScreenController.PlayButtonClicked += OnPlayButtonClicked;
        }

        private async UniTask RunScreenLoading()
        {
            _loadingScreen.Open();

            await _gameLoopService.ChangeValue(0, 1, 1, value =>
                _loadingScreen.SetProgress(value));

            await UniTask.NextFrame();

            _loadingScreen.Close();
        }

        private void OnPlayButtonClicked()
        {
            _stateMachine.Enter<LevelState>();
        }
        
        protected override void OnExit()
        {
            _sceneLoader.UnloadScene(_assets.PlayerRenderSceneName);
            _mainScreenController.PlayButtonClicked -= OnPlayButtonClicked;

            _uiCloseService.CloseAll();
            _mainScreenController = null;
            _uiCloseService = null;
            _assets = null;
            _sceneLoader = null;
        }
    }
}