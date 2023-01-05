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
        public RegistrationState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }
        
        protected override void OnEnter(MonoServices monoServices)
        {
            IGameObjectService gameObjectService =
                DiContainer.Register<GameObjectService, IGameObjectService>();

            DiContainer.Register<PhysicsService, IPhysicsService>();
            DiContainer.Register<ICoroutineRunnerService>(monoServices.CoroutineRunnerService);
            DiContainer.Register<ApplicationInputService, IApplicationInputService>();
            DiContainer.Register<IApplicationService>(monoServices.ApplicationService);
            DiContainer.Register<SceneLoaderService, ISceneLoaderService>();
            DiContainer.Register<ScreenService, IScreenService>();
            DiContainer.Register<JsonSerializerService, IJsonSerializerService>();
            DiContainer.Register<PlayerPrefsService, IPlayerPrefsService>();
            DiContainer.Register<UserService, IUserAccessService, IUserSaveService>();
            DiContainer.Register<VibrationService, IVibrationService>();
            DiContainer.Register<IAssetsService>(monoServices.AssetsService);
            DiContainer.Register<PoolService, IPoolCreatorService, IPoolSpawnerService>(monoServices.PoolService);
            DiContainer.Register<TimeService, ITimeService>();
            DiContainer.Register<FpsService, IFpsService>();
            DiContainer.Register<IAudioService>(monoServices.AudioService);
            DiContainer.Register<IBalanceService>(monoServices.BalanceService);
            DiContainer.Register<UiService, IUiService, IUiRefreshService, IUiCloseService>(monoServices.UiService);

            gameObjectService.DontDestroyOnLoad(monoServices.gameObject);

            _stateMachine.Enter<BootstrapState>();
        }
    }
}