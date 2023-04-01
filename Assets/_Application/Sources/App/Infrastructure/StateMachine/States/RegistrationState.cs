using Sources.App.Game.UI.System;
using Sources.App.Infrastructure.ApplicationInput;
using Sources.App.Infrastructure.Bootstrap;
using Sources.App.Infrastructure.Services;
using Sources.App.Infrastructure.Services.ApplicationCycle;
using Sources.App.Infrastructure.Services.AssetsManager;
using Sources.App.Infrastructure.Services.Audio;
using Sources.App.Infrastructure.Services.Balance;
using Sources.App.Infrastructure.Services.CoroutineRunner;
using Sources.App.Infrastructure.Services.Fps;
using Sources.App.Infrastructure.Services.Gizmoses;
using Sources.App.Infrastructure.Services.Instantiator;
using Sources.App.Infrastructure.Services.JsonSerializer;
using Sources.App.Infrastructure.Services.Physics;
using Sources.App.Infrastructure.Services.PlayerPreferences;
using Sources.App.Infrastructure.Services.Pool;
using Sources.App.Infrastructure.Services.Quality;
using Sources.App.Infrastructure.Services.SceneLoader;
using Sources.App.Infrastructure.Services.Screens;
using Sources.App.Infrastructure.Services.Times;
using Sources.App.Infrastructure.Services.User;
using Sources.App.Infrastructure.Services.Vibration;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;

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
            _diBuilder.Register<Balance>(monoServices.BalanceService);
            _diBuilder.Register<UiService, IUiService, IUiRefreshService, IUiCloseService>(monoServices.UiService);
            _diBuilder.Register<IGizmosService>(monoServices.GizmosService);
            _diBuilder.Register<QualityService, IQualityAccessService, IQualityChangerService>();

            gameObjectService.DontDestroyOnLoad(monoServices.gameObject);

            _stateMachine.Enter<BootstrapState>();
        }
    }
}