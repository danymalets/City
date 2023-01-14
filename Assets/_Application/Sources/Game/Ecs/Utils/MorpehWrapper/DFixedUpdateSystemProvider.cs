using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DFixedUpdateSystemProvider<TUpdateSystem> : FixedUpdateSystem
        where TUpdateSystem : DUpdateSystem, new()
    {
        private readonly TUpdateSystem _dSystem;

        public DFixedUpdateSystemProvider()
        {
            _dSystem = new TUpdateSystem();
        }

        public override void OnAwake()
        {
            _dSystem.Setup(World);
            _dSystem.InitFilters();
            _dSystem.Initialize();
        }

        public override void OnUpdate(float deltaTime)
        {
            _dSystem.Update(deltaTime, true);
        }
    }
}