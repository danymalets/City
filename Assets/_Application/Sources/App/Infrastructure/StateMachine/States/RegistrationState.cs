using Sources.App.Core.Services.Quality;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.Monos.MonoServices;
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
using Sources.Services.UiServices.System;
using Sources.Services.VibrationServices;
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
            _diBuilder.Register<ICoroutineService>(monoServices.CoroutineService);
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
            _diBuilder.Register<LocalizationService, ILocalizationService>();
            _diBuilder.Register<IUiViewsService>(new UiViewsService(monoServices.UiViews));
            _diBuilder.Register<IGizmosService>(monoServices.GizmosService);
            _diBuilder.Register<QualityService, IQualityAccessService, IQualityChangerService>();
            
            _diBuilder.Register<AdsService, IAdsService>();
            _diBuilder.Register<AnalyticsService, IAnalyticsService>();
            _diBuilder.Register<IapService, IIapService>();
            
            _diBuilder.Register<UiControllersService, IUiControllersService, IUiRefreshService, IUiCloseService>(
                new UiControllersService(monoServices.UiViews));

            gameObjectService.DontDestroyOnLoad(monoServices.gameObject);

            _stateMachine.Enter<BootstrapState>();
        }
    }
}