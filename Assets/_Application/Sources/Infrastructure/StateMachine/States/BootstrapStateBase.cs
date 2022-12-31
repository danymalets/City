using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Bootstrap.Installers;
using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.ApplicationCycle;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Audio;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.Pool;
using Sources.Infrastructure.Services.Pool.Instantiators;
using Sources.Infrastructure.Services.SceneLoader;
using Sources.Infrastructure.Services.Times;
using Sources.Infrastructure.Services.Vibration;
using Sources.Infrastructure.StateMachine.Machine;
using Sources.Infrastructure.StateMachine.StateBase;
using Sources.UI.Screens;
using Sources.UI.System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Sources.Infrastructure.StateMachine.States
{
    public class BootstrapStateBase : GameState<UiSystem, MonoServices>
    {
        public BootstrapStateBase(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }
        
        protected override void OnEnter(UiSystem uiSystem, MonoServices monoServices)
        {
            IGameObjectService gameObjectService =
                DiContainer.Register<IGameObjectService>(new GameObjectService());
            
            DiContainer.Register<ICoroutineRunnerService>(monoServices.CoroutineRunnerService);
            DiContainer.Register<ISceneLoaderService>(new SceneLoaderService());
            DiContainer.Register<IApplicationCycleService>(monoServices.ApplicationCycleService);
            DiContainer.Register<IVibrationService>(new VibrationService());
            DiContainer.Register<IAssetsService>(monoServices.AssetsService);
            DiContainer.Register<IPoolService>(monoServices.PoolService);
            DiContainer.Register<ITimeService>(new TimeService());
            DiContainer.Register<IAudioService>(monoServices.AudioService);
            //DiContainer.Register<IBalanceService>(monoServices.BalanceService);

            uiSystem.Initialize();

            gameObjectService.DontDestroyOnLoad(monoServices.gameObject);
            gameObjectService.DontDestroyOnLoad(uiSystem.gameObject);
            
            _stateMachine.Enter<LoadLevelStateBase>();
        }
    }
}