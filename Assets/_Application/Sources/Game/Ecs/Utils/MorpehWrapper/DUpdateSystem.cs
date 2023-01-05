using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public abstract class DUpdateSystem
    {
        protected World _world;

        protected DUpdateSystem(World world)
        {
        }

        public void SetupWorld(World world) =>
            _world = world;

        public void Update(float deltaTime) =>
            OnUpdate(deltaTime);

        protected abstract void OnUpdate(float deltaTime);
    }
}