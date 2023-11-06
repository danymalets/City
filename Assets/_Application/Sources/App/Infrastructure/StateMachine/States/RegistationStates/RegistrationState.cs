using Sources.App.Core.Services.Quality;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Infrastructure.StateMachine.States.BootstrapStates;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AudioServices;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.UserServices;
using Sources.App.Ui.Base;
using Sources.Services.AdsServices;
using Sources.Services.AnalyticsServices;
using Sources.Services.ApplicationInputServices;
using Sources.Services.ApplicationServices;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.FpsServices;
using Sources.Services.GizmosServices;
using Sources.Services.IapServices;
using Sources.Services.InstantiatorServices;
using Sources.Services.JsonSerializerServices;
using Sources.Services.LocalizationServices;
using Sources.Services.PhysicsServices;
using Sources.Services.PlayerPreferencesServices;
using Sources.Services.PoolServices;
using Sources.Services.SceneLoaderServices;
using Sources.Services.ScreenServices;
using Sources.Services.TimeServices;
using Sources.Services.VibrationServices;
using Sources.Utils.Di;

namespace Sources.App.Infrastructure.StateMachine.States.RegistationStates
{
    public class RegistrationState : GameState<BootstrapData>
    {
        private IDiBuilder _diBuilder;

        public RegistrationState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }
        
        protected override void OnEnter(BootstrapData bootstrapData)
        {
            MonoServicesData monoServicesData = bootstrapData.MonoServicesData;
            
            _diBuilder = DiBuilder.Create();
            
            IGameObjectService gameObjectService = 
                _diBuilder.Register<GameObjectService, IGameObjectService>();

            _diBuilder.Register<PhysicsService, IPhysicsService>();
            _diBuilder.Register<ICoroutineService>(monoServicesData.CoroutineService);
            _diBuilder.Register<ApplicationInputService, IApplicationInputService>();
            _diBuilder.Register<IApplicationService>(monoServicesData.ApplicationService);
            _diBuilder.Register<SceneLoaderService, ISceneLoaderService>();
            _diBuilder.Register<ScreenService, IScreenService>();
            _diBuilder.Register<JsonSerializerService, IJsonSerializerService>();
            _diBuilder.Register<PlayerPrefsService, IPlayerPrefsService>();
            _diBuilder.Register<UserService, IUserAccessService, IUserSaveService>();
            _diBuilder.Register<VibrationService, IVibrationService>();
            _diBuilder.Register<Assets>(monoServicesData.Assets);
            _diBuilder.Register<PoolService, IPoolCreatorService, IPoolSpawnerService, IPoolDespawnerService>(
                new PoolService(monoServicesData.PoolRoot));
            _diBuilder.Register<TimeService, ITimeService>();
            _diBuilder.Register<FpsService, IFpsService>();
            _diBuilder.Register<IAudioService>(monoServicesData.AudioService);
            _diBuilder.Register<Balance>(monoServicesData.BalanceService);
            _diBuilder.Register<LocalizationService, ILocalizationService>();
            _diBuilder.Register<IGizmosService>(monoServicesData.GizmosService);
            _diBuilder.Register<QualityService, IQualityAccessService, IQualityChangerService>();
            
            _diBuilder.Register<AdsService, IAdsService>();
            _diBuilder.Register<AnalyticsService, IAnalyticsService>();
            _diBuilder.Register<IapService, IIapService>();
            
            _diBuilder.Register<UiControllersService, IUiControllersService, IUiRefreshService, IUiCloseService>(
                new UiControllersService(monoServicesData.UiViews));

            gameObjectService.DontDestroyOnLoad(monoServicesData.gameObject);


#if !FORCE_DEBUG
            gameObjectService.Destroy(bootstrapData.DebugMenu);
#endif

            _stateMachine.Enter<BootstrapState>();
        }
    }
}