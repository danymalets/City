using System;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Systems
{
    public abstract class DUpdateSystem : DSystem
    {
        protected DUpdateSystem()
        {
        }

        protected override void OnInitFilters()
        {
        }

        public void Update(float deltaTime)
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