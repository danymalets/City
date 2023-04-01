using Sources.App.Game.UI.System;
using Sources.AssetsManager;
using Sources.Services.ApplicationCycle;
using Sources.Services.Audio;
using Sources.Services.CoroutineRunner;
using Sources.Services.Gizmoses;
using Sources.Services.Pool;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.App.Infrastructure.Bootstrap
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
        private Balance.Balance _balanceService;
        [SerializeField]
        private GizmosService _gizmosService;

        public UiService UiService => _uiService;
        public CoroutineRunnerService CoroutineRunnerService => _coroutineRunnerService;
        public ApplicationService ApplicationService => _applicationService;
        public PoolService PoolService => _poolService;
        public AudioService AudioService => _audioService;
        public Assets Assets => _assets;
        public Balance.Balance BalanceService => _balanceService;
        public GizmosService GizmosService => _gizmosService;
    }
}