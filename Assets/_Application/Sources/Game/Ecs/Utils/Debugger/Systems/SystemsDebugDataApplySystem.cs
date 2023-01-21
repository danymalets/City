using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Utils.Debugger.Components;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.Debugger.Systems
{
    public class SystemsDebugDataApplySystem : DUpdateSystem
    {
        private Filter _filter;
        private SystemsDebugger _systemsDebugger;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<SystemsDebugComponent>();
        }

        protected override void OnInitialize()
        {
            GameObject systemsDebuggerObj = new();
            _systemsDebugger = systemsDebuggerObj.AddComponent<SystemsDebugger>();

            ref SystemsDebugComponent systemsDebug = 
                ref _world.CreateEntity().Add<SystemsDebugComponent>().Get<SystemsDebugComponent>();

            systemsDebug.Data = new SystemsDebugData();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref SystemsDebugComponent systemsDebugComponent = ref entity.Get<SystemsDebugComponent>();
                SystemsDebugData systemsDebugData = systemsDebugComponent.Data;

                _systemsDebugger.UpdateSystemsData(systemsDebugData);
                
                systemsDebugComponent.Data = new SystemsDebugData();
            }
        }
    }
}