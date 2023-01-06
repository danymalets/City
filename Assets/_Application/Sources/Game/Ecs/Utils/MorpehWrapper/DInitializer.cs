using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public abstract class DInitializer
    {
        protected World _world;

        public void SetupWorld(World world) =>
            _world = world;

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