namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public abstract class DFixedUpdateSystem : DSystem
    {
        public void InitFilters() =>
            OnInitFilters();

        protected abstract void OnInitFilters();

        public void Initialize() =>
            OnInitialize();

        protected virtual void OnInitialize()
        {
        }

        public void FixedUpdate(float fixedDeltaTime) =>
            OnFixedUpdate(fixedDeltaTime);

        protected abstract void OnFixedUpdate(float fixedDeltaTime);
    }
}