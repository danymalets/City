using System;
using Sources.Services.GizmosServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Systems
{
    public abstract class CustomSystem
    {
        protected CustomWorld _world;
        protected IGizmosService _gizmos;
        protected GizmosContext _updateGizmosContext;

        public void Setup(CustomWorld world)
        {
            _world = world;
            _gizmos = DiContainer.Resolve<IGizmosService>();
            _updateGizmosContext = _gizmos.CreateContext();
        }
        
        public void InitFilters() =>
            OnInitFilters();

        protected abstract void OnInitFilters();
    }
}