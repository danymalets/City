using Sources.Services.ApplicationCycle;
using Sources.Services.AssetsManager;
using Sources.Services.Audio;
using Sources.Services.BalanceManager;
using Sources.Services.CoroutineRunner;
using Sources.Services.Gizmoses;
using Sources.Services.Pool;
using Sources.Services.Ui.System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Services.MonoServices
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
        [FormerlySerializedAs("_assetsService")]
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
        public Services.BalanceManager.Balance BalanceService => _balanceService;
        public GizmosService GizmosService => _gizmosService;
    }
}