using Sources.CommonServices.ApplicationServices;
using Sources.CommonServices.CoroutineRunnerServices;
using Sources.CommonServices.GizmosServices;
using Sources.CommonServices.PoolServices;
using Sources.CommonServices.UiServices.System;
using Sources.ProjectServices.AudioServices;
using Sources.ProjectServices.BalanceServices;
using UnityEngine;

namespace Sources.ProjectServices.AssetsServices.Monos.MonoServices
{
    public class MonoServices : MonoBehaviour
    {
        [SerializeField]
        private UiService _uiService;
        [SerializeField]
        private CoroutineRunnerService _coroutineRunnerService;
        [SerializeField]
        private ApplicationService _applicationService;
        [SerializeField]
        private PoolService _poolService;
        [SerializeField]
        private AudioService _audioService;
        [SerializeField]
        private Assets _assets;
        [SerializeField]
        private Balance _balanceService;
        [SerializeField]
        private GizmosService _gizmosService;

        public UiService UiService => _uiService;
        public CoroutineRunnerService CoroutineRunnerService => _coroutineRunnerService;
        public ApplicationService ApplicationService => _applicationService;
        public PoolService PoolService => _poolService;
        public AudioService AudioService => _audioService;
        public Assets Assets => _assets;
        public Balance BalanceService => _balanceService;
        public GizmosService GizmosService => _gizmosService;
    }
}