using Sources.Infrastructure.ApplicationInput;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.ApplicationCycle;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Audio;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.Fps;
using Sources.Infrastructure.Services.Instantiator;
using Sources.Infrastructure.Services.JsonSerializer;
using Sources.Infrastructure.Services.PlayerPreferences;
using Sources.Infrastructure.Services.Pool;
using Sources.Infrastructure.Services.Pool.Instantiators;
using Sources.Infrastructure.Services.SceneLoader;
using Sources.Infrastructure.Services.Screens;
using Sources.Infrastructure.Services.Times;
using Sources.Infrastructure.Services.User;
using Sources.Infrastructure.Services.Vibration;
using Sources.Infrastructure.StateMachine.Machine;
using Sources.Infrastructure.StateMachine.StateBase;
using Sources.UI.System;
using UnityEngine;

namespace Sources.Infrastructure.StateMachine.States
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
            _diBuilder.Register<IAssetsService>(monoServices.AssetsService);
            _diBuilder.Register<PoolService, IPoolCreatorService, IPoolSpawnerService>(monoServices.PoolService);
            _diBuilder.Register<TimeService, ITimeService>();
            _diBuilder.Register<FpsService, IFpsService>();
            _diBuilder.Register<IAudioService>(monoServices.AudioService);
            _diBuilder.Register<IBalanceService>(monoServices.BalanceService);
            _diBuilder.Register<UiService, IUiService, IUiRefreshService, IUiCloseService>(monoServices.UiService);

            gameObjectService.DontDestroyOnLoad(monoServices.gameObject);

            _stateMachine.Enter<BootstrapState>();
        }
    }
}