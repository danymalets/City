using Sources.Infrastructure.Services;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap.InstallersBase
{
    public abstract class MonoServiceInstaller<TImplementation, TService> : 
        ServiceInstaller<TImplementation, TService> 
        where TImplementation : Object, TService 
        where TService : class, IService
    {
        private const string ServicesPath = "Services";
        
        private readonly Transform _parent;
        private readonly IGameObjectService _gameObject;

        protected MonoServiceInstaller(Transform parent)
        {
            _parent = parent;
            _gameObject = DiContainer.Resolve<IGameObjectService>();
        }

        protected override TImplementation GetService()
        {
            TImplementation prefab = Resources.LoadAll<TImplementation>(ServicesPath)[0];
            return _gameObject.Instantiate(prefab, _parent);
        }
    }
}