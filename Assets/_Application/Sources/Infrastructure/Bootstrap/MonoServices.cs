using Sources.Infrastructure.Services.ApplicationCycle;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Audio;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.CoroutineRunner;
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
        private GameObject _servicesRoot;
        [SerializeField]
        private CoroutineRunnerService _coroutineRunnerService;
        [SerializeField]
        private ApplicationService _applicationService;
        [SerializeField]
        private PoolCreatorService _poolCreatorService;
        [SerializeField]
        private AudioService _audioService;
        [SerializeField]
        private AssetsService _assetsService;
        [SerializeField]
        private BalanceService _balanceService;
        
        public UiService UiService => _uiService;
        public GameObject ServicesRoot => _servicesRoot;
        public CoroutineRunnerService CoroutineRunnerService => _coroutineRunnerService;
        public ApplicationService ApplicationService => _applicationService;
        public PoolCreatorService PoolCreatorService => _poolCreatorService;
        public AudioService AudioService => _audioService;
        public AssetsService AssetsService => _assetsService;
        public BalanceService BalanceService => _balanceService;
    }
}