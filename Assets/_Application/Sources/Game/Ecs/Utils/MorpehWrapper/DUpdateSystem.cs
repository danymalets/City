using System;
using DefaultNamespace;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Utils.Debugger;
using Sources.Game.Ecs.Utils.Debugger.Components;
using Sources.Infrastructure.Services.Gizmoses;
using Sources.Utilities;
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
            try
            {
                string name = GetType().Name;
                long ticks = DPerformance.Execute(() => OnUpdate(deltaTime));
                SystemsDebugData systemsDebugData = _world.GetSingleton<SystemsDebugComponent>().Data;

                SystemDebugData systemDebugData = new(name, ticks);

                if (isFixed)
                {
                    systemsDebugData.AddFixedData(systemDebugData);
                }
                else
                {
                    systemsDebugData.AddUpdateData(systemDebugData);
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }

        protected abstract void OnUpdate(float deltaTime);
    }
}