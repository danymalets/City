using Sources.App.Services.AudioServices;
using Sources.App.Services.BalanceServices;
using Sources.Services.ApplicationServices;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.GizmosServices;
using Sources.Services.PoolServices;
using Sources.Services.UiServices.System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.App.Services.AssetsServices.Monos.MonoServices
{
    public class MonoServices : MonoBehaviour
    {
        [SerializeField]
        private UiService _uiService;
        [FormerlySerializedAs("_coroutineRunnerService")]
        [SerializeField]
        private CoroutineService _coroutineService;
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
        public CoroutineService CoroutineService => _coroutineService;
        public ApplicationService ApplicationService => _applicationService;
        public PoolService PoolService => _poolService;
        public AudioService AudioService => _audioService;
        public Assets Assets => _assets;
        public Balance BalanceService => _balanceService;
        public GizmosService GizmosService => _gizmosService;
    }
}