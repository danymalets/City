using Sources.App.Game.UI.System;
using Sources.App.Infrastructure.ApplicationInput;
using Sources.App.Infrastructure.Bootstrap;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.AssetsManager;
using Sources.Di;
using Sources.Services.ApplicationCycle;
using Sources.Services.Audio;
using Sources.Services.CoroutineRunner;
using Sources.Services.Fps;
using Sources.Services.Gizmoses;
using Sources.Services.Instantiator;
using Sources.Services.JsonSerializer;
using Sources.Services.Physics;
using Sources.Services.PlayerPreferences;
using Sources.Services.Pool;
using Sources.Services.Quality;
using Sources.Services.SceneLoader;
using Sources.Services.Screens;
using Sources.Services.Times;
using Sources.Services.Vibration;
using Sources.User;

namespace Sources.App.Infrastructure.StateMachine.States
{
    public class RegistrationState : GameState<MonoServices>
    {
        private IDiBuilder _diBuilder;

        public RegistrationState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }
        
        protected override void OnEnter(MonoServices monoServices)
        {
            _diBuilder = DiBuilder.Create();
            
            IGameObjectService gameObjectService =
                _diBuilder.Register<GameObjectService, IGameObjectService>();

            _diBuilder.Register<PhysicsService, IPhysicsService>();
            _diBuilder.Register<ICoroutineRunnerService>(monoServices.CoroutineRunnerService);
            _diBuilder.Register<ApplicationInputService, IApplicationInputService>();
            _diBuilder.Register<IApplicationService>(monoServices.ApplicationService);
            _diBuilder.Register<SceneLoaderService, ISceneLoaderService>();
            _diBuilder.Register<ScreenService, IScreenService>();
            _diBuilder.Register<JsonSerializerService, IJsonSerializerService>();
            _diBuilder.Register<PlayerPrefsService, IPlayerPrefsService>();
            _diBuilder.Register<UserService, IUserAccessService, IUserSaveService>();
            _diBuilder.Register<VibrationService, IVibrationService>();
            _diBuilder.Register<Assets>(monoServices.Assets);
            _diBuilder.Register<PoolService, IPoolCreatorService, IPoolSpawnerService>(monoServices.PoolService);
            _diBuilder.Register<TimeService, ITimeService>();
            _diBuilder.Register<FpsService, IFpsService>();
            _diBuilder.Register<IAudioService>(monoServices.AudioService);
            _diBuilder.Register<Balance.Balance>(monoServices.BalanceService);
            _diBuilder.Register<UiService, IUiService, IUiRefreshService, IUiCloseService>(monoServices.UiService);
            _diBuilder.Register<IGizmosService>(monoServices.GizmosService);
            _diBuilder.Register<QualityService, IQualityAccessService, IQualityChangerService>();

            gameObjectService.DontDestroyOnLoad(monoServices.gameObject);

            _stateMachine.Enter<BootstrapState>();
        }
    }
}