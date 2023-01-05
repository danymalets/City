using Scellecs.Morpeh.Systems;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DUpdateSystemProvider<TDSystem> : UpdateSystem where TDSystem : DUpdateSystem, new()
    {
        private readonly TDSystem _dSystem;

        public DUpdateSystemProvider()
        {
            _dSystem = new TDSystem();
            _dSystem.SetupWorld(World);
        }

        public override void OnAwake()
        {
            if (_dSystem is IDInitializeSystem initializeSystem)
            {
                initializeSystem.Initialize();
            }
        }

        public override void OnUpdate(float deltaTime)
        {
            _dSystem.Update(deltaTime);
        }
    }
}