using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DFixedUpdateSystemProvider<TUpdateSystem> : IFixedSystem
        where TUpdateSystem : DUpdateSystem, new()
    {
        private readonly TUpdateSystem _dSystem;

        public DFixedUpdateSystemProvider()
        {
            _dSystem = new TUpdateSystem();
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
            _dSystem.Update(deltaTime, true);
        }

        public void Dispose()
        {
        }
    }
}