using System.Collections.Generic;
using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Pool;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class PoolInstaller : MonoServiceInstaller<PoolService, IPoolService>
    {
        public PoolInstaller(Transform parent) : base(parent)
        {
        }

        protected override void Setup(PoolService implementation)
        {
            IAssetsService assets = DiContainer.Resolve<IAssetsService>();

            List<PoolConfig> poolConfigs = new List<PoolConfig>();

            //setup

            foreach (PoolConfig poolConfig in poolConfigs)
                implementation.CreatePool(poolConfig);
        }
    }
}