using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.ApplicationCycle;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Audio;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.Instantiator;
using Sources.Infrastructure.Services.Pool;
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
            
            DiContainer.Register<IApplicationService>(monoServices.ApplicationService);
            DiContainer.Register<ScreenService, IScreenService>();
            DiContainer.Register<PhysicsService, IPhysicsService>();
            DiContainer.Register<ICoroutineRunnerService>(monoServices.CoroutineRunnerService);
            DiContainer.Register<SceneLoaderService, ISceneLoaderService>();
            DiContainer.Register<UserService, IUserAccessService, IUserSaveService>();
            DiContainer.Register<VibrationService, IVibrationService>();
            DiContainer.Register<IAssetsService>(monoServices.AssetsService);
            DiContainer.Register<IPoolCreatorService>(monoServices.PoolCreatorService);
            DiContainer.Register<TimeService, ITimeService>();
            DiContainer.Register<IAudioService>(monoServices.AudioService);
            DiContainer.Register<IBalanceService>(monoServices.BalanceService);
            DiContainer.Register<UiService, IUiService, IUiRefreshService, IUiCloseService>(monoServices.UiService);

            gameObjectService.DontDestroyOnLoad(monoServices.UiService.gameObject);
            gameObjectService.DontDestroyOnLoad(monoServices.ServicesRoot);

            _stateMachine.Enter<BootstrapState>();
        }
    }
}