using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public abstract class DInitializer : DSystem
    {
        public void InitFilters() =>
            OnInitFilters();

        protected virtual void OnInitFilters()
        {
        }

        public void Initialize() =>
            OnInitialize();

        protected abstract void OnInitialize();
    }
}