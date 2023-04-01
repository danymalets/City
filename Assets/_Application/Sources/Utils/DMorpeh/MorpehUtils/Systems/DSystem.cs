using System;
using Sources.Services.Di;
using Sources.Services.Gizmoses;
using UnityEngine;

namespace Sources.Utils.DMorpeh.MorpehUtils.Systems
{
    public abstract class DSystem
    {
        protected DWorld _world;
        protected IGizmosService _gizmos;
        protected GizmosContext _updateGizmosContext;

        public void Setup(DWorld world)
        {
            _world = world;
            _gizmos = DiContainer.Resolve<IGizmosService>();
            _updateGizmosContext = _gizmos.CreateContext();
        }
        
        public void Construct() =>
            OnConstruct();

        protected abstract void OnConstruct();

        public void Initialize()
        {
            try
            {
                OnInitialize();
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }

        protected virtual void OnInitialize()
        {
        }
    }
}