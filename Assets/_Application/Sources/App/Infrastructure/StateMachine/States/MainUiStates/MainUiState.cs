using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Infrastructure.StateMachine.States.LevelStates;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.Monos.MonoEntities.Player;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.CurrencyScreens;
using Sources.App.Ui.Screens.MainScreens;
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

        public MainUiState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            IUiControllersService uiControllers = DiContainer.Resolve<IUiControllersService>();
            
            _mainScreenController = uiControllers.Get<MainScreenController>();
            _currencyScreenController = uiControllers.Get<CurrencyScreenController>();

            _uiCloseService = DiContainer.Resolve<IUiCloseService>();

            _mainScreenController.Open();
            _currencyScreenController.Open();
            
            _assets = DiContainer.Resolve<Assets>();
            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();

            _sceneLoader.LoadEmptyScene(() =>
            {
            });
            _sceneLoader.LoadScene<PlayerRenderSceneContext>(_assets.PlayerRenderSceneName, playerRenderSceneContext =>
            {
                PlayerMonoEntity player = playerRenderSceneContext.Player;
                _mainScreenController.PlayButtonClicked += OnPlayButtonClicked;
            }, LoadSceneMode.Additive); 
        }

        private void OnPlayButtonClicked()
        {
            _stateMachine.Enter<LevelState>();
        }
        
        protected override void OnExit()
        {
            _sceneLoader.UnloadScene(_assets.PlayerRenderSceneName, () =>
            {
                
            });
            
            _mainScreenController.PlayButtonClicked -= OnPlayButtonClicked;

            _uiCloseService.CloseAll();
            _mainScreenController = null;
            _uiCloseService = null;
            _assets = null;
            _sceneLoader = null;
        }
    }
}