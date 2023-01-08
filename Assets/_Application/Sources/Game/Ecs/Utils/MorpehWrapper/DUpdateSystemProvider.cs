using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DUpdateSystemProvider<TDSystem> : UpdateSystem where TDSystem : DUpdateSystem, new()
    {
        private readonly TDSystem _dSystem;

        public DUpdateSystemProvider()
        {
            _dSystem = new TDSystem();
        }

        public override void OnAwake()
        {
            _dSystem.Setup(World);
            _dSystem.InitFilters();
            _dSystem.Initialize();
        }

        public override void OnUpdate(float deltaTime)
        {
            _dSystem.Update(deltaTime);
        }
    }
}