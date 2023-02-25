using System;
using Sources.Game.Ecs.Utils.Debugger;
using Sources.Infrastructure.Services.Gizmoses;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public abstract class DUpdateSystem : DSystem
    {
        protected DUpdateSystem()
        {
        }

        protected override void OnConstruct()
        {
        }

        protected override void OnInitialize()
        {
            
        }

        public void Update(float deltaTime, bool isFixed = false)
        {
            _updateGizmosContext.ClearAll();
            
            TryUpdate(deltaTime);
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