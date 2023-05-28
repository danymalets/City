namespace Sources.Utils.MorpehWrapper.MorpehUtils.Systems
{
    public abstract class DPeriodUpdateSystem : DUpdateSystem
    {
        private int _remainingCount = 0;
        private float _deltaTime = 0;
        protected abstract int Period { get; }
        
        protected sealed override void OnUpdate(float deltaTime)
        {
            _remainingCount--;
            _deltaTime += deltaTime;
            
            if (_remainingCount <= 0)
            {
                OnPeriodUpdate(_deltaTime);
                _remainingCount = Period;
                _deltaTime = 0;
            }
        }

        protected abstract void OnPeriodUpdate(float deltaTime);
    }
}