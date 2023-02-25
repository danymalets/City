using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DInitializerProvider<TDInitializer> : IInitializer where TDInitializer : DInitializer, new()
    {
        private readonly TDInitializer _dSystem;

        public DInitializerProvider()
        {
            _dSystem = new TDInitializer();
        }

        public void OnAwake()
        {
            _dSystem.Setup(World);
            _dSystem.Construct();
            _dSystem.Initialize();
        }

        public World World { get; set; }

        public void Dispose()
        {
        }
    }
}