using Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Systems
{
    public abstract class DIntervalUpdateSystem : DUpdateSystem
    {
        private float _remainingTime = 0;
        protected abstract float ExecuteInterval { get; }
        
        protected sealed override void OnUpdate(float deltaTime)
        {
            _remainingTime -= deltaTime;
            
            if (DMath.LessOrEquals(_remainingTime, 0))
            {
                OnIntervalUpdate(_remainingTime);
                _remainingTime = ExecuteInterval;
            }
        }

        protected abstract void OnIntervalUpdate(float deltaTime);
    }
}