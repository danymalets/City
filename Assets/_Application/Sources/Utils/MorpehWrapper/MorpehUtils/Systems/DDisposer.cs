using System;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Systems
{
    public abstract class DDisposer : DSystem
    {
        protected override void OnInitFilters()
        {
            
        }
        
        public void Dispose()
        {
            try
            {
                OnDispose();
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }

        protected abstract void OnDispose();
    }
}