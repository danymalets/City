using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DUpdateSystemProvider<TSystem> : UpdateSystem where TSystem : DUpdateSystem, new()
    {
        private readonly TSystem _dSystem;

        public DUpdateSystemProvider()
        {
            _dSystem = new TSystem();
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