using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DUpdateSystemProvider<TSystem> : ISystem where TSystem : DUpdateSystem, new()
    {
        private readonly TSystem _dSystem;

        public DUpdateSystemProvider()
        {
            _dSystem = new TSystem();
        }

        public void OnAwake()
        {
            _dSystem.Setup(World);
            _dSystem.Construct();
            _dSystem.Initialize();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            _dSystem.Update(deltaTime);
        }

        public void Dispose()
        {
        }
    }
}