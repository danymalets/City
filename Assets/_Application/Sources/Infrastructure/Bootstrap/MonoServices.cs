using Sources.Infrastructure.Services.ApplicationCycle;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Audio;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.Gizmoses;
using Sources.Infrastructure.Services.Pool;
using Sources.UI.System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Bootstrap
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
        public Balance BalanceService => _balanceService;
        public GizmosService GizmosService => _gizmosService;
    }
}