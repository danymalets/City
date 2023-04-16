using System;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Systems
{
    public abstract class DInitializer : DSystem
    {
        protected override void OnInitFilters()
        {
            
        }
        
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