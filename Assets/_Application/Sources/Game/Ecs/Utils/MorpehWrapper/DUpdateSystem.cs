using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public abstract class DUpdateSystem
    {
        protected World _world;

        public void SetupWorld(World world) =>
            _world = world;

        public void InitFilters() =>
            OnInitFilters();

        protected abstract void OnInitFilters();

        public void Initialize() =>
            OnInitialize();

        protected virtual void OnInitialize()
        {
        }

        public void Update(float deltaTime) =>
            OnUpdate(deltaTime);

        protected abstract void OnUpdate(float deltaTime);
    }
}