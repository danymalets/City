using Sources.Infrastructure.Services.ApplicationCycle;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Audio;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.Pool;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap
{
    public class MonoServices : MonoBehaviour
    {
        [SerializeField]
        private CoroutineRunnerService _coroutineRunnerService;
        [SerializeField]
        private ApplicationCycleService _applicationCycleService;
        [SerializeField]
        private AssetsService _assetsService;
        [SerializeField]
        private PoolService _poolService;
        [SerializeField]
        private AudioService _audioService;
        [SerializeField]
        private BalanceService _balanceService;
        
        public CoroutineRunnerService CoroutineRunnerService => _coroutineRunnerService;
        public ApplicationCycleService ApplicationCycleService => _applicationCycleService;
        public AssetsService AssetsService => _assetsService;
        public PoolService PoolService => _poolService;
        public AudioService AudioService => _audioService;
        public BalanceService BalanceService => _balanceService;
    }
}