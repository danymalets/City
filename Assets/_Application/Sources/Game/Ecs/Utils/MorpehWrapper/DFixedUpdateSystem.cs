using System;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Gizmoses;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public abstract class DFixedUpdateSystem : DSystem
    {
        protected GizmosContext _fixedUpdateGizmosContext;

        public void InitFilters() =>
            OnInitFilters();

        protected abstract void OnInitFilters();

        public void Initialize()
        {
            _fixedUpdateGizmosContext = _gizmos.CreateContext();
            OnInitialize();
        }

        protected virtual void OnInitialize()
        {
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _fixedUpdateGizmosContext.ClearAll();
            try
            {
                OnFixedUpdate(fixedDeltaTime);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }

        protected abstract void OnFixedUpdate(float fixedDeltaTime);
    }
}