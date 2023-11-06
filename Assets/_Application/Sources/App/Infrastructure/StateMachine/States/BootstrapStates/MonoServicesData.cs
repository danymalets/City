using Sources.App.Services.AssetsServices;
using Sources.App.Services.AudioServices;
using Sources.App.Services.BalanceServices;
using Sources.App.Ui.Base.Views;
using Sources.Services.ApplicationServices;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.GizmosServices;
using Sources.Services.PoolServices;
using UnityEngine;

namespace Sources.App.Infrastructure.StateMachine.States.BootstrapStates
{
    public class MonoServicesData : MonoBehaviour
    {
        [field: SerializeField] public UiViews UiViews { get; private set; }
        [field: SerializeField] public CoroutineService CoroutineService { get; private set; }
        [field: SerializeField]  public ApplicationService ApplicationService { get; private set; }
        [field: SerializeField] public Transform PoolRoot { get; private set; }
        [field: SerializeField] public AudioService AudioService { get; private set; }
        [field: SerializeField] public Assets Assets { get; private set; }
        [field: SerializeField] public Balance BalanceService { get; private set; }
        [field: SerializeField] public GizmosService GizmosService { get; private set; }
    }
}