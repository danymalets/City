using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.CommonServices.ApplicationInputServices;
using Sources.CommonServices.ApplicationServices;
using Sources.CommonServices.CoroutineRunnerServices;
using Sources.CommonServices.FpsServices;
using Sources.CommonServices.GizmosServices;
using Sources.CommonServices.InstantiatorServices;
using Sources.CommonServices.JsonSerializerServices;
using Sources.CommonServices.PhysicsServices;
using Sources.CommonServices.PlayerPreferencesServices;
using Sources.CommonServices.PoolServices;
using Sources.CommonServices.SceneLoaderServices;
using Sources.CommonServices.ScreenServices;
using Sources.CommonServices.TimeServices;
using Sources.CommonServices.UiServices.System;
using Sources.CommonServices.VibrationServices;
using Sources.Monos.MonoServices;
using Sources.ProjectServices.AssetsServices;
using Sources.ProjectServices.AudioServices;
using Sources.ProjectServices.BalanceServices;
using Sources.ProjectServices.QualityServices;
using Sources.ProjectServices.UserServices;
using Sources.Utils.Di;

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
            _diBuilder.Register<PoolService, IPoolCreatorService, IPoolSpawnerService, IPoolDespawnerService>(monoServices.PoolService);
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