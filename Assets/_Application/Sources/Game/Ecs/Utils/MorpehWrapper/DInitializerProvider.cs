using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DInitializerProvider<TDInitializer> : Initializer where TDInitializer : DInitializer, new()
    {
        private readonly TDInitializer _dSystem;

        public DInitializerProvider()
        {
            _dSystem = new TDInitializer();
        }

        public override void OnAwake()
        {
            _dSystem.Setup(World);
            _dSystem.InitFilters();
            _dSystem.Initialize();
        }
    }
}