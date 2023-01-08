using Scellecs.Morpeh.Systems;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DFixedUpdateSystemProvider<TDFixedUpdateSystem> : FixedUpdateSystem 
        where TDFixedUpdateSystem : DFixedUpdateSystem, new()
    {
        private readonly TDFixedUpdateSystem _dSystem;

        public DFixedUpdateSystemProvider()
        {
            _dSystem = new TDFixedUpdateSystem();
        }

        public override void OnAwake()
        {
            _dSystem.Setup(World);
            _dSystem.InitFilters();
            _dSystem.Initialize();
        }

        public override void OnUpdate(float fixedDeltaTime)
        {
            _dSystem.FixedUpdate(fixedDeltaTime);
        }
    }
}