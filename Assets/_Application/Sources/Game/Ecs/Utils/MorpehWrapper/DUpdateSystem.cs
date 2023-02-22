using System;
using Sources.Game.Ecs.Utils.Debugger;
using Sources.Infrastructure.Services.Gizmoses;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public abstract class DUpdateSystem : DSystem
    {
        protected GizmosContext _updateGizmosContext;

        public void InitFilters() =>
            OnInitFilters();

        protected abstract void OnInitFilters();

        public void Initialize()
        {
            _updateGizmosContext = _gizmos.CreateContext();
            OnInitialize();
        }

        protected virtual void OnInitialize()
        {
        }

        public void Update(float deltaTime, bool isFixed = false)
        {
            _updateGizmosContext.ClearAll();

            string name = GetType().Name;

            long ticks = 0;
            // long ticks = DPerformance.Execute(() =>
            // {
                    TryUpdate(deltaTime);
            // });

            SystemDebugData systemDebugData = new(name, ticks);
        }

        private void TryUpdate(float deltaTime)
        {
            try
            {
                OnUpdate(deltaTime);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }

        protected abstract void OnUpdate(float deltaTime);
    }
}